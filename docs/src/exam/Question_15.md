# 15. Алгоритмы реализации соединений отношений в SQL

Для того, чтобы обеспечить целостность, мы будем заниматься денормализацией _(создавать множество связанных таблиц)_.

Это приводит к снижению **производительности**.

> Соединение таблиц - это дорого!

## 1. Неэффективно (декартово произведение)

> Вложенный цикл

```csharp
for (int i = 0; i < R.Count; ++i)
{
    for (int j = 0; j < S.Count; ++j)
    {
        if (R[i].atr != S[j].atr) continue;
        Console.WriteLine(r + s);
    }
}
```

```py
for r in R
    for s in S
        if (r.atr == s.atr)
            print(r + s)
```

## 2. Эффективно

> Предварительная сортировка

```py
R.sort(atr)
S.sort(atr)

while not EndOF(S) ans not EndOF(R)
    if (r.atr < s.atr)
        next(R)
    if (r.atr = s.atr)
        print(r + s)
        next(R)
    if (r.atr > s.atr)
        next(S)
```

