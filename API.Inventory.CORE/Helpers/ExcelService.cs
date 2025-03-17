
using System.Globalization;
using System.Reflection;
using ClosedXML.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace API.Inventory.CORE.Helpers;

public class ExcelService : IDisposable
{
    private readonly XLWorkbook _workbook;
    
    public ExcelService()
    {
        _workbook = new XLWorkbook();
    }
    
    public MemoryStream ExportExcel<T>(List<T> data, string sheetName)
    {
        var stream = new MemoryStream();
        if (data.Count == 0) return stream;

        var worksheet = _workbook.Worksheets.Add(sheetName);

        // Create header
        var properties = typeof(T).GetProperties();
        for (var i = 0; i < properties.Length; i++)
        {
            worksheet.Cell(1, i + 1).Value = properties[i].Name;
            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
        }

        // Insert data and format cells
        for (var i = 0; i < data.Count; i++)
        {
            for (var j = 0; j < properties.Length; j++)
            {
                var value = properties[j].GetValue(data[i]);
                var cell = worksheet.Cell(i + 2, j + 1);

                // Convert value to appropriate type
                if (value is DateTime dateTimeValue)
                {
                    if (dateTimeValue == DateTime.MinValue) continue;
                    cell.Value = dateTimeValue;
                    cell.Style.DateFormat.Format = "yyyy-mm-dd";
                }
                else if (value is int intValue)
                {
                    cell.Value = intValue;
                    cell.Style.NumberFormat.Format = "0";
                }
                else if (value is long longValue)
                {
                    cell.Value = longValue;
                    cell.Style.NumberFormat.Format = "0";
                }
                else if (value is short shortValue)
                {
                    cell.Value = shortValue;
                    cell.Style.NumberFormat.Format = "0";
                }
                else if (value is decimal decimalValue)
                {
                    cell.Value = decimalValue;
                    cell.Style.NumberFormat.Format = "0.00";
                }
                else if (value is double doubleValue)
                {
                    cell.Value = doubleValue;
                    cell.Style.NumberFormat.Format = "0.00";
                }
                else if (value is float floatValue)
                {
                    cell.Value = floatValue;
                    cell.Style.NumberFormat.Format = "0.00";
                }
                else
                {
                    cell.Value = value?.ToString();
                }
            }
        }

        _workbook.SaveAs(stream);
        return stream;
    }
    
    public static async Task<List<T>> ImportExcelAsync<T>(List<Stream> fileStreams) where T : new()
    {
        var result = new List<T>();

        foreach (var fileStream in fileStreams)
        {
            try
            {
                // Intenta abrir con ClosedXML
                using var workbook = new XLWorkbook(fileStream);
                var worksheet = workbook.Worksheet(1);
                result.AddRange(ProcessWorksheet<T>(worksheet));
            }
            catch (FileFormatException)
            {
                // Si falla, intenta convertir de XLS a XLSX y reintenta
                fileStream.Position = 0;
                var convertedStream = ConvertXlsToXlsx(fileStream);
                using var workbook = new XLWorkbook(convertedStream);
                var worksheet = workbook.Worksheet(1);
                result.AddRange(ProcessWorksheet<T>(worksheet));
            }
        }

        return await Task.FromResult(result);
    }

    private static object ConvertValue(string value, Type targetType)
    {
        if (targetType == typeof(int) && int.TryParse(value, out int intResult)) return intResult;
        if (targetType == typeof(long) && long.TryParse(value, out long longResult)) return longResult;
        if (targetType == typeof(short) && short.TryParse(value, out short shortResult)) return shortResult;
        if (targetType == typeof(decimal) && decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalResult)) return decimalResult;
        if (targetType == typeof(double) && double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleResult)) return doubleResult;
        if (targetType == typeof(float) && float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatResult)) return floatResult;
        if (targetType == typeof(DateTime) && DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTimeResult)) return dateTimeResult;
        if (targetType == typeof(bool) && bool.TryParse(value, out bool boolResult)) return boolResult;

        return Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);
    }
    
    private static MemoryStream ConvertXlsToXlsx(Stream xlsStream)
    {
        try
        {
            xlsStream.Position = 0; // Reiniciar el stream antes de leerlo
            var hssfWorkbook = new HSSFWorkbook(xlsStream);
            var xssfWorkbook = new XSSFWorkbook();

            for (var i = 0; i < hssfWorkbook.NumberOfSheets; i++)
            {
                var sheet = hssfWorkbook.GetSheetAt(i);
                var newSheet = xssfWorkbook.CreateSheet(sheet.SheetName);

                foreach (IRow row in sheet)
                {
                    var newRow = newSheet.CreateRow(row.RowNum);
                    foreach (var cell in row.Cells)
                    {
                        var newCell = newRow.CreateCell(cell.ColumnIndex, cell.CellType);
                        newCell.SetCellValue(cell.ToString());
                    }
                }
            }

            var memoryStream = new MemoryStream();
            xssfWorkbook.Write(memoryStream, leaveOpen: true); // IMPORTANTE: Evitar cerrar el stream
            memoryStream.Position = 0; // Reiniciar el stream para su lectura
            return memoryStream;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al convertir el archivo XLS a XLSX.", ex);
        }
    }
    
    private static List<T> ProcessWorksheet<T>(IXLWorksheet worksheet) where T : new()
    {
        var result = new List<T>();
        var rows = worksheet.RowsUsed().ToList();
        if (rows.Count == 0) return result;

        var headerRow = rows.First();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var propertyMap = new Dictionary<int, PropertyInfo>();

        // Mapear columnas con las propiedades del modelo
        for (var j = 0; j < headerRow.Cells().Count(); j++)
        {
            var header = headerRow.Cell(j + 1).Value.ToString().Trim();
            var property = properties.FirstOrDefault(p => p.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
            if (property != null)
            {
                propertyMap[j] = property;
            }
        }

        // Leer las filas de datos
        foreach (var row in rows.Skip(1))
        {
            var obj = new T();
            for (var j = 0; j < row.Cells().Count(); j++)
            {
                if (!propertyMap.TryGetValue(j, out var property)) continue;

                var cell = row.Cell(j + 1);
                var value = cell.Value.ToString().Trim();

                if (string.IsNullOrEmpty(value)) continue;

                try
                {
                    var convertedValue = ConvertValue(value, property.PropertyType);
                    property.SetValue(obj, convertedValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al convertir la celda {cell.Address}: {ex.Message}");
                }
            }

            result.Add(obj);
        }

        return result;
    }
    
    public void Dispose()
    {
        _workbook.Dispose();
    }
}