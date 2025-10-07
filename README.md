Zadania wykonane: 2 - 6
zadanie 6 znajduje się na dole w readme

Jako że do oceny miała włynąć struktura projektu to sam projekt został opracowany w oparciu o Domain-Driven Design (DDD) oraz SOLID (pomimo że to mały projekcik i mało się w nim dzieje obecnie :D)
Celem było stworzenie czytelnej, skalowalnej i łatwej w utrzymaniu architektury aplikacji WPF opartej o .NET Framework 4.8 oraz Entity Framework (z plikiem EDMX) + LINQ.

Pominąłem tu dobre zasady comitowania czyli nie rozdzielałem to na branche a następnie nie mergowałem tego do głównego brancha przez pull-request.
mam nadzieję że to nie będzie oceniane :D

Część UI nie została dokończona, miała w prosty graficzny sposób prezentować dane odnośnie pracowników ich przełożonych a także informacje na temat wniosków urlopowych każdego z pracowników
zadanie nie było wymagane więc na tą chwilę jest nie dokończone, możliwe że uda się dokończyć przed sprawdzeniem :)


 Zastosowane wzorce

DDD – rozdzielenie logiki domenowej, aplikacyjnej i infrastrukturalnej.
SOLID – każda klasa ma pojedynczą odpowiedzialność (Single Responsibility Principle).


 Architektura warstwowa

Projekt został podzielony na niezależne warstwy zgodne z zasadami DDD:

EmploTaskTwo.Domain – definiuje logikę domenową: encje, interfejsy repozytoriów.
Ta warstwa jest całkowicie niezależna od technologii i nie zawiera żadnych odniesień do baz danych ani frameworków.

EmploTaskTwo.Application – odpowiada za logikę aplikacyjną.
Zawiera serwisy aplikacyjne, interfejsy serwisów, DTO, oraz stałe (ApplicationConstants).
W tej warstwie implementowana jest logika biznesowa operująca na modelach domenowych przy pomocy repozytoriów.
Zastosowałem tu wzorzec Application Service oraz centralizację stałych w klasie ApplicationConstants.

EmploTaskTwo.Infrastructure – implementacja repozytoriów w oparciu o Entity Framework (EDMX).
Zawiera także mapery oraz konfigurację dostępu do danych.
Repozytoria są zgodne z interfejsami z warstwy Domain i komunikują się z bazą danych wyłącznie poprzez DbContext.

EmploTaskTwo.Core – warstwa pomocnicza przechowująca elementy wspólne, takie jak ErrorMessages, DateProvider oraz inne klasy współdzielone pomiędzy projektami.
Umożliwia centralne zarządzanie stałymi, komunikatami i utilami.

EmploTaskTwo.UI (WPF) – warstwa prezentacji.
Zawiera widoki, ViewModel’e
Wykorzystuje serwisy aplikacyjne jako źródło danych i logiki.

EmploTaskTwo.UnitTests – testy jednostkowe oparte o framework NUnit oraz bibliotekę Moq.
Stosowane mocki (EmployeeMockData, VacationMockData) umożliwiają testowanie logiki aplikacji bez rzeczywistej bazy danych.
Testy zostały napisane zgodnie z zasadą Arrange-Act-Assert.


Zadanie 6

<br />

1) Eager loading - jako że domyślnie EF korzysta z lazy loading czyli każde odwołanie do właściwości nawigacyjnej (np. employee.Vacations) co generuje osobne zapytanie SQL 
to zamiast tego można wczytać wszystkie potrzebne dane od razu jednym zapytaniem po przez Include.

Przykład: 

var employee = _context.Employees <br />
    .Include(e => e.Vacations) <br />
    .FirstOrDefault(e => e.Id == employeeId); 

  <br />

2) Batching / Preloading danych

Możemy pobrać za jednym razem więcej danych i je przechowywać zamiast naprzykład robić tego w pętli

Przykład:

var employeeIds = employees.Select(e => e.Id).ToList();

var vacations = context.Vacations <br />
    .Where(v => employeeIds.Contains(v.EmployeeId)) <br />
    .ToList();

<br />

3) AsNoTracking()

Jeśli dane mają być tylko odczytane, nie muszą być śledzone przez kontekst EF.
Wyłączenie ich „trackingu” przyspieszy i zmniejszy obciążenie pamięci. (wykorzystałem to w projekcie)

<br />

4) Agregacje po stronie SQL 

Zamiast pobierać pełne dane i wykonywać część operacji jak sumowanie w C#, można to zrobić po stronie SQL.

Przykład:

int totalHoursUsed = context.Vacations <br />
    .Where(v => v.EmployeeId == employeeId && v.DateSince.Year == currentYear) <br />
    .Sum(v => v.NumberOfHours);

możemy też użyć GROUP BY by znacąco ograniczyć ilość zapytań dla wielu jednostek

<br />

 5) Zamiast pobierać całe encje z bazy możemy wybrać co naprawdę jest nam potrzebne. 

Przykład:

var employeeData = _context.Employees <br />
    .Where(e => e.Id == employeeId) <br />
    .Select(e => new  <br />
    { <br />
        e.Id, <br />
        e.Name, <br />
        Vacations = e.Vacations <br />
            .Where(v => v.DateSince.Year == currentYear) <br />
            .Select(v => new { v.NumberOfHours }) <br />
    }) <br />
    .FirstOrDefault();
