# 14. Структура и порядок выполнения предложения Select в SQL

## Как выглядит SELECT

```sql
SELECT [DISTINCT | ALL] { * | [ColumsExpression [AS NewName], ... ] }
FROM TableName [AS NewName]
    [ { INNER | LEFTOUTER | FULL } JOIN ] TasbeName2 [AS NewName]
    ON condition ]
[ WHERE condition ]
[ GROUP BY ColumnList ]
[ HAVING condition ]
[ ORDER BY ColumnList [ ASC | DESC ]]
```

## Последовательность выполнения SELECT

1. `FROM`
2. `JOIN ... ON`
3. `WHERE`
4. `GROUP BY`
5. `HAVING`
6. `SELECT`
7. `DISTINCT`
8. `ORDER BY`

