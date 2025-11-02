using Microsoft.Data.SqlClient;

namespace GeneralSamples.Classes;

public  class SqlClientHelpers
{
    public static  DateOnly GetDateOnly(SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index);

    public static  TimeOnly GetTimeOnly(SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index);

    public static  string GetTimeOnlyFormatted(SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index).ToString("hh:mm tt");

    public static  string GetDateOnlyFormatted(SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index).ToString("MM/dd/yyyy");
}
