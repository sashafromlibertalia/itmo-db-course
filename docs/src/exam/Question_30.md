# 30. Двенадцать правил Дейта распределенных БД

1. **Локальная автономность**

    Локальные данные принадлежат локальным владельцам и локально сопровождаются (на каждом узле есть свой управленец БД и только он имеет к ним доступ управления)

2. **Отсутствие опоры на центральный узел**

    В системе не должно быть ни одного узла, без которого система не может функционировать

3. **Непрерывное функционирование**

    В системе не должна возникать потребность в плановом останове её функционирования

4. **Независимость от расположения**

    Любой пользователь может получить доступ к данным, хранящимся на любом узле

5. **Независимость от фрагментации**

    Любой пользователь может получить доступ к данным, вне зависимости от их фрагментации

6. **Независимость от репликации**

    Любой пользователь может получить доступ к данным, вне зависимости от наличия реплик

7. **Обработка распределённых запросов**

    Любой пользователь должен иметь возможность обработать любой запрос вне зависимости от количества узлов, на которых расположены запрашиваемые объекты данных

8. **Обработка распределённых транзакций**

    Система должна поддерживать выполнение транзакций с данными, расположенными более чем на одном узле

9. **Независимость от типа оборудования**

    Очев

10. **Независимость от сетевой архитектуры**

    Очев

11. **Независимость от операционной системы**

    Очев

12. **Независимость от типа СУБД**

    Очев

