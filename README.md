﻿# Платформа для обмена кулинарными рецептами

## 1. Название продукта
Платформа для обмена кулинарными рецептами и идеями для приготовления блюд.

## 2. Введение
Этот проект представляет собой платформу, на которой пользователи могут добавлять, обновлять и делиться кулинарными рецептами, включая ингредиенты, время приготовления и инструкции.

## 3. Необходимые условия для использования продукта
- .NET Core 5.0 или выше
- Среда разработки (IDE) — Visual Studio или Visual Studio Code
- Основы работы с Git и GitHub

## 4. Как установить программу
1. Скачайте и установите .NET Core с [официального сайта](https://dotnet.microsoft.com/download).
2. Клонируйте репозиторий с GitHub:
   ```bash
   git clone https://github.com/ваш_репозиторий.git
   ```
3. Откройте проект в вашей IDE и выполните команду:
   ```bash
   dotnet run
   ```

## 5. Порядок использования
1. После запуска приложения откройте браузер и перейдите по адресу `http://localhost:5000`.
2. Используйте API для добавления, обновления и удаления рецептов с помощью методов `POST`, `PUT`, `DELETE`.
3. Пример использования:
   - Добавить рецепт:
     ```bash
     curl -X POST -H "Content-Type: application/json" -d '{"DishName":"Pasta","Ingredients":["Tomato","Cheese"],"CookingTime":30,"Instructions":"Mix and cook for 30 minutes."}' http://localhost:5000/api/recipe/add
     ```
4. Для более подробной документации обращайтесь к [документации проекта](ссылка_на_документацию).

![Логотип](https://octodex.github.com/images/orderedlistocat.png "Логотип GitHub")





