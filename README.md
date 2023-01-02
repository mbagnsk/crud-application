# Warehouse Manager - crud application

Projekt wykonano w ramach przedmiotu: Projekt przejściowy.    
Celem projektu było wykonanie aplikacji desktopowej wykorzystującej bazę danych. Umożliwiającej przedstawianie, dodawanie, modyfikowanie oraz usuwanie danych zebranych w tabelach. 

## Wykorzystane technologie
W ramach projektu wykorzystano technologie:
  - .NET:
    - WPF - aplikacja dekstopowa,
    - C# - logika aplikacji,
    - Linq - zarządzanie kolekcją danych.
  - Microsoft SQL Server:
    - utworzenie tabel,
    - relacyjny model danych,
    - SQL - procedury, zapytania.
  - Git/Github - system kontroli wersji,
  
## Model danych
![image](https://user-images.githubusercontent.com/56918406/209851859-82cb7ad3-773c-4f7f-af3a-5685cf9518f5.png)
Zadecydowano, aby w ramach projektu wykorzystać relacyjny model danych. Utworzono następujące tabele:
  - CUSTOMERS - tabela zawierająca dane kontrahentów:
    - **IDClient** - numer identyfikacyjny kontrahenta,
    - Company - nazwa kontrahenta,
    - Nip - numer NIP kontrahenta,
    - Street - ulica, element adresu kontrahenta,
    - BuildingNumber - numer budynku, element adresu kontrahenta,
    - LocalNumber - numer lokalu, element adresu kontrahenta(jeśli konieczny),
    - ZIPCode - kod pocztowy, element adresu kontrahenta,
    - Email - adres email kontrahenta,
    - PhoneNumber - numer telefonu kontrahenta.
  - INVOICES - tabela zawierająca wystawione faktury:
    - **IDInvoice** - numer identyfikacyjny faktury,
    - ***IDClient*** - numer identyfikacyjny klienta, 
    - OrderDatetime - data oraz czas wykonania zamówienia,
    - DueDate - data wymagalności,
    - PaymentDate - data wpłaty kwoty przez kontrahenta,
    - PaymentAmount - ilość wpłaconych pieniędzy przez kontrahenta,
    - OrderActive - informacja o tym czy zamówienie nie zostało anulowane.
  - PRODUCTS - tabela zawierająca oferowane produkty:
    - **IDProduct** - numer identyfikacyjny produktu,
    - ProductName - nazwa produktu,
    - ProductDescription - opis produktu,
    - NetPrice - cena netto produktu,
    - GrossPrice - cena brutto produktu,
    - PriceActiveFrom - informacja od kiedy kwota była aktywna,
    - PriceActiveTo - informacja do kiedy kwota była aktywna.
  - ORDERS - tabela zawierająca produkty zamówione w ramach faktury:
    - ***IDInvoice*** - numer identyfikacyjny faktury,
    - ***IDProduct*** - numer identyfikacyjny produktu,
    - Quantity - ilość zamówionego produktu.

Pola:
  - **wytłuszczone** - klucze główne,
  - ***wytłuszczone z kursywą*** - klucze obce.
  
Większość z pól w rezalizowanych tabelach zostały stworzone z wartością NOT NULL co oznacza, że muszą one posiadać wartość. Dodatkowo część z pól będącymi kluczami głównymi posiadają własność autoinkrementacji przy dodawaniu kolejnego rekordu. Umożliwia to na automatyczne nadawanie kolejnych wartości ID w tabelach.

W ramach projektu zrealizowano również procedury wbudowane umożliwiające na dodanie oraz pobranie danych z bazy danych. Powodem, dla którego zadecydowano o wykorzystaniu procedur wbudowanych była możliwość ich wywołania z wielu poziomów tj. z aplikacji mobilnej lub webowej gdyby takowe powstały. Na poziomie procedur wbudowanych nie jest zapewniona transakcyjność operacji. Transakcyjność  jest zapewniana dopiero na poziomie logiki aplikacji desktopowej.  
Utworzone procedury:
  - AddClient - dodanie kontrahenta,
  - AddInvoice - dodanie faktury,
  - AddOrder - dodanie produktu do zamówienia ,
  - AddProduct - dodanie oferowanego produktu,
  - GetInvoices - pobranie faktur,
  - GetOrderElements - pobranie produktów zamówionych w ramach faktury,
  - GetInvoiceNetPrice - pobranie wartości netto zamówienia,
  - GetInvoiceGrossPrice - probanie wartości brutto zamówienia.
  

  
