# Various items for teaching

System.ComponentModel.[DataAnnotations](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-5.0) Namespace

**Figure 1** standard

```csharp
[Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
[MaxLength(12, ErrorMessage = "The {0} can not have more than {1} characters")]
[Display(Name = "First name")]
public string FirstName { get; set; }
```

**Figure 2** custom

```csharp
[ValidCountryName(ErrorMessage = "Country name is required")]
public string CountryName => Country.CountryName;
```


**Figure 3**

When two namespaces are used with the same code we need to alias to get the right one. Typically on an average day this is not needed but good to know.

```csharp
using RLC = RulesLibrary.Classes;
```



## Get column max width

```sql
USE NorthWind2020;
DECLARE @TableName SYSNAME= 'Customers';
SELECT col.COLUMN_NAME, 
       col.DATA_TYPE, 
       col.CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.TABLES AS tbl
     INNER JOIN INFORMATION_SCHEMA.COLUMNS AS col ON col.TABLE_NAME = tbl.TABLE_NAME
     INNER JOIN sys.columns AS sc ON sc.object_id = OBJECT_ID(tbl.TABLE_SCHEMA + '.' + tbl.TABLE_NAME)
                                     AND sc.name = col.COLUMN_NAME
     LEFT JOIN sys.extended_properties prop ON prop.major_id = sc.object_id
                                               AND prop.minor_id = sc.column_id
WHERE tbl.TABLE_NAME = @TableName AND col.CHARACTER_MAXIMUM_LENGTH IS NOT NULL

ORDER BY col.ORDINAL_POSITION;
```