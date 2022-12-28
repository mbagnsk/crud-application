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
    - IDClient - numer identyfikacyjny kontrahenta,
    - Company - nazwa kontrahenta,
    - Nip - numer NIP kontrahenta,
    - Street - ulica, element adresu kontrahenta,
    - BuildingNumber - numer budynku, element adresu kontrahenta,
    - LocalNumber - numer lokalu, element adresu kontrahenta(jeśli konieczny),
    - ZIPCode - kod pocztowy, element adresu kontrahenta,
    - Email - adres email kontrahenta,
    - PhoneNumber - numer telefonu kontrahenta.
  - INVOICES - tabela zawierająca wystawione faktury:
    - IDInvoice - numer identyfikacyjny faktury,
    - IDClient - numer identyfikacyjny klienta, 
    - OrderDatetime - data oraz czas wykonania zamówienia,
    - DueDate - data wymagalności,
    - PaymentDate - data wpłaty kwoty przez kontrahenta,
    - PaymentAmount - ilość wpłaconych pieniędzy przez kontrahenta,
    - OrderActive - informacja o tym czy zamówienie nie zostało anulowane.
  - PRODUCTS - tabela zawierająca oferowane produkty:
    - IDProduct - numer identyfikacyjny produktu,
    - ProductName - nazwa produktu,
    - ProductDescription - opis produktu,
    - NetPrice - cena netto produktu,
    - GrossPrice - cena brutto produktu,
    - PriceActiveFrom - informacja od kiedy kwota była aktywna,
    - PriceActiveTo - informacja do kiedy kwota była aktywna.
  - ORDERS - tabela zawierająca produkty zamówione w ramach faktury:
    - IDInvoice - numer identyfikacyjny faktury,
    - IDProduct - numer identyfikacyjny produktu,
    - Quantity - ilość zamówionego produktu.
