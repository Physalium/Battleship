# Battleship by Karol Nawrot


W celu wykonania zadania przyjąłem następujące założenia:
- Plansza ma rozmiar 10x10
- Wybór statków wygląda tak: 1 x pięciomasztowiec, 1 x czteromasztowiec, 2 x trójmasztowiec oraz 1 x dwumasztowiec
- Statki nie mogą się ze sobą stykać bokami
- Symulacja zachowania graczy polega na prioretyzacji trafień w okolicę trafionych statków, dopiero w przypadku sprawdzenia wszystkich pól sąsiadujących z trafionymi statkami, jest przeszukiwana pozostała część planszy

Struktura projektu polega na podziale na 3 części: BattleShipCore - bibliotece zawierającej całą logikę gry, BattleShipApi - część odpowiedzialna za wystawienie api z endpointem do generacji gry oraz zwróceniu jej przebiegu jako odpowiedź, battleship-client - front aplikacji napisany w React.js, wyświetla on planszę gry oraz statystyki np. trafione statki.

API posiada proste zabezpieczenie w postaci statycznego api-key, który dla uproszczenia uruchomienia projektu jest umieszczony w pliku .env po stronie frontendu, oraz w appsettings.json po stronie API. Docelowo klucz powinien znaleźć się w specjalnym środowisku do przetrzymywania wrażliwych danych, np. Secret Manager w środowisku .NET.

Podczas implementacji napotkałem problem z kwestią przekazania informacji o przebiegu gry, dokładniej ze stworzeniem obiektu DTO, który posiadałby potrzebne przez frontend dane w celu wyświetlenia przebiegu gry. Miałem do wyboru zrobienie tego po stronie API lub samej biblioteki. Ostatecznie zdecydowałem, że ograniczę rolę API jedynie do wywoływania metody generacji oraz zwracania obiektu o przebiegu gry przygotowanego przez bibliotekę główną.
