# 🎮 Kółko i Krzyżyk z AI (Dynamiczny Rozmiar Planszy)

![Platform](https://img.shields.io/badge/.NET-8.0-blue.svg)
![Language](https://img.shields.io/badge/Language-C%23-green.svg)
![UI](https://img.shields.io/badge/UI-Windows%20Forms-orange.svg)

Klasyczna gra w "Kółko i Krzyżyk" zaimplementowana w języku C# na platformie .NET. Aplikacja pozwala na rozgrywkę jednoosobową z zaawansowanym komputerowym przeciwnikiem (AI) na planszy o niestandardowych, definiowanych przez użytkownika wymiarach.



## ✨ Funkcje aplikacji

* **Dynamiczny rozmiar planszy:** Możliwość wyboru wymiarów siatki ($n \times n$).
* **Konfigurowalna długość wygranej:** Użytkownik sam określa, ile znaków w rzędzie (pion, poziom, skosy) daje zwycięstwo.
* **Inteligentne AI:** Przeciwnik komputerowy analizuje sytuację na planszy i dąży do wygranej lub blokowania ruchów gracza.
* **Separacja logiki (Architektura MVC):** Silnik matematyczny gry (`TicTacToeEngine`) jest w 100% niezależny od warstwy okienkowej grafiki (`Form1`).

---

## 🤖 Zastosowane technologie i algorytmy

* **Platforma:** .NET (C#)
* **Interfejs graficzny:** Windows Forms (WinForms) z dynamicznym generowaniem kontrolek w czasie uruchomienia.
* **Sztuczna inteligencja (AI):**
  * **Algorytm MinMax:** Przeszukiwanie drzewa stanów gry w celu znalezienia optymalnego ruchu.
  * **Odcięcia Alfa-Beta (Alpha-Beta Pruning):** Zaawansowana optymalizacja redukująca liczbę sprawdzanych węzłów, zapewniająca natychmiastową odpowiedź komputera.
  * **Heurystyczny limit głębokości:** Ograniczenie kroków algorytmu dla dużych plansz ($n > 3$), chroniące przed zamrożeniem interfejsu.

---

## 🛠️ Jak uruchomić projekt

### Wymagania wstępne
* Zainstalowane środowisko **Microsoft Visual Studio 2022** (lub nowsze).
* Zainstalowany zestaw obciążeń **.NET Desktop Development** (programowanie aplikacji klasycznych).

### Uruchomienie kroki:
1. Sklonuj to repozytorium na swój dysk:
   ```bash
   git clone [https://github.com/TWOJ-NICK/NAZWA-REPOZYTORIUM.git](https://github.com/TWOJ-NICK/NAZWA-REPOZYTORIUM.git)
