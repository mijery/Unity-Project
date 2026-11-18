LAST EMBER - СТАРТОВЫЙ НАБОР ГРАФИКИ

Куда положить: Assets/_Project/Art/

НАСТРОЙКИ ИМПОРТА ДЛЯ ВСЕХ PNG
Texture Type: Sprite (2D and UI)
Pixels Per Unit: 16
Filter Mode: Point (no filter)
Compression: None

НАРЕЗКА (Sprite Mode: Multiple, Sprite Editor > Slice > Grid By Cell Size)
Characters/hero_keeper_16x32.png          ячейка 16x32, Pivot: Bottom
Characters/enemy_shadow_runner_16x18.png  ячейка 16x18, Pivot: Bottom
Objects/campfire_32x32.png                ячейка 32x32, Pivot: Bottom
Tilesets/ground_autumn_16x16.png          ячейка 16x16, Pivot: Center

Остальные файлы в Objects: Sprite Mode: Single, Pivot: Bottom.

ГЕРОЙ
Строки сверху вниз: вниз, влево, вправо, вверх.
Столбцы 1-2: покой. Столбцы 3-6: ходьба.
Скорость: покой 2 кадра/с, ходьба 8 кадров/с.
Когда подключите анимации влево и вправо, оставьте поле Sprite Renderer
в PlayerMovement пустым, иначе спрайт будет отражаться дважды.

РЫЦАРЬ
Characters/hero_knight_32x32.png: ячейка 32x32, Pivot: Bottom.
Порядок строк и столбцов такой же, как у героя выше.
Characters/hero_knight_showcase_96x96.png: большой арт для меню и питча,
Sprite Mode: Single.

КОСТЁР И ВРАГ
4 кадра в строке, цикл. Костёр 8 кадров/с, враг 6 кадров/с.

ТАЙЛСЕТ
Строка 1: столбцы 1-4 трава, 5 трава с листьями, 6 трава с цветами, 7-8 земля.
Строки 2-3: 16 переходов между травой и землёй.
Номер перехода = сумма углов, где находится земля:
верхний левый 1, верхний правый 2, нижний левый 4, нижний правый 8.
Нумерация идёт слева направо: строка 2 содержит 0-7, строка 3 содержит 8-15.
