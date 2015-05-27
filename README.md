# Kolokwium - zestaw1


## Scenariusz dla projektu Word Searcher
Celem zadania jest przygotowanie aplikacji, która pozwala wprowadzić tekst oraz przeszukiwać go.  Celem przeszukiwania użytkownik wprowadza słowo klucz oraz wybiera metodę przeszukiwania. Przeszukiwanie odbywa się na dwa sposoby: tekst zawierający słowo klucz lub tekst zaczynający się od słowa klucz. Dodatkowo użytkownik ma możliwość zapisania listy wcześniej wprowadzonych słów kluczy, użytych do przeszukiwania. Aplikacja jest skonstruowana w oparciu o podejście MVVM.

O ile nie napisano inaczej, cały kod należy napisać w klasie odpowiadającej warstwie ViewModel. Warstwa View jest już zaimplementowana i nie powinna być zmieniana. W ramach implementacji klasy TextViewModel należy dostarczyć brakujących składowych (właściwa część zadania). Tam, gdzie mowa o przeszukiwaniu należy użyć kwerendy LINQ.

Z projektem dostarczone są:
* Klasy pomocnicze:
  * Globals – odpowiedzialna za trzymanie stałych pomocniczych
  * MyDispatcher – odpowiedzialna za wywołanie akcji przekazanej do metody RunOnUi na wątku głównym aplikacji (instancja jest dostarczona pod postacią interfejsu IDispatcher)
  * MyCommand – odpowiedzialna za dostarczenie uproszczonej implementacji dla interfejsu System.Windows.Input.ICommand
* Klasy do implementacji przeszukiwania:
  * ASearcher – klasa bazowa dla logiki przeszukiwania
  * StartsWithSearcher – klasa implementująca strategię przeszukiwania dla słów zaczynających się od zadanego tekstu
  * ContainsSearcher – klasa implementująca strategię przeszukiwania dla słów zawartych w zadanym tekście



### Zadanie 1: Jako użytkownik chcę widzieć ekran ze wszystkimi dostępnymi funkcjami celem wprowadzenia tekstu do przeszukiwania.

Kryteria oceny:
* Należy zaimplementować interfejs ITextViewModel w klasie o nazwie TextViewModel.
* Właściwości z metodami get/set wywołuje zdarzenie pochodzące z interfejsu INotifyPropertyChanged w momencie przypisania wartości.
* Właściwość SearchMethods zwraca kolekcję dwóch obiektów (po jednym z klas ContainsSearcher i StartsWithSearcher). 
* Właściwość SelectedMethod jest ustawiona na pierwszy element z kolekcji SearchMethods.

Wskazówki:
* Właściwość Content może być domyślnie ustawiona do przykładowego tekstu, dostępnego w stałej Globals.LoremIpsum.
* Właściwości typu ICommand mogą być zaimplementowane za pomocą udostępnionej klasy MyCommand.

### Zadanie 2: Jako użytkownik chcę wpisać słowo kluczowe oraz wybrać metodę wyszukiwania celem przeprowadzenia przeszukania.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy SearchCommand.
* Przeszukiwanie odbywa się gdy tekst wprowadzony dla właściwości o nazwie Query, ma wartość różną od null i nie jest pustym tekstem oraz tekst wprowadzony dla właściwości tekstu przeszukiwanego o nazwie Content także nie jest nullem ani nie jest pusty.
* Przeszukiwanie odbywa się przez podzielenie tekstu na słowa (metoda Split oraz dzielenie po „białych znakach”), a następnie zsumowanie liczby słów odpowiadających kryterium wyszukiwania (metoda SelectedMethod.VerifyText). Kryterium wyszukiwania to wybrana metoda (SelectedMethod), z ustawionym słowem kluczem służącym do przeszukiwania (Query).
* Jeżeli brak jest rezultatów wyszukiwania lub nie można wyszukać to w SearchResult należy pokazać tekst "No results" (można skorzystać ze stałej Globals.NoSearchResults. Jeżeli liczba wyników wyszukiwania jest dodatnia, to należy pokazać liczbę wyników w formacie „Results found: LICZBA” (można skorzystać ze stałej Globals.ResultsFound).

Wskazówki:
* Porównywanie tekstu do wyszukiwania jest zabiegiem czasochłonnym. Należy mieć to na uwadze implementując rozwiązanie.

### Zadanie 3: Jako użytkownik chcę, żeby system zapamiętał słowa kluczowe wprowadzone do kolejnych prób przeszukiwania celem późniejszej analizy.

Kryteria oceny:
* Należy uzupełnić klasę TextViewModel o kolekcję, w której zapamiętywane są kolejne słowa kluczowe używane w próbach przeszukiwania. Czas życia kolekcji jest taki sam jak obiektu klasy TextViewModel.
* Należy zaimplementować „zapamiętywanie” kolejnych słów kluczowych w w/w kolekcji, w ramach metody odpowiadającej na wykonanie komendy SearchCommand.

### Zadanie 4: Jako użytkownik chcę zapisać na dysku kolekcję słów kluczowych wprowadzonych do kolejnych prób wyszukiwania, celem późniejszej analizy.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy SaveSearchesCommand.
* Zawartość kolekcji, w której zapamiętane są słowa kluczowe (patrz Zadanie 3) jest zapisana w pliku tymczasowym i formacie JSON.

Wskazówki:
* Do implementacji zapisu do formatu JSON można użyć dodatkowej biblioteki dostarczonej w ramach środowiska .NET.
* Operacje wejścia/wyjścia są zabiegami czasochłonnymi. Należy mieć to na uwadze implementując rozwiązanie.

### Zadanie 5: Należy zmodyfikować strukturę klas wywiedzionych z klasy ASearcher, tak aby ASearcher była klasą abstrakcyjną, a implementacja właściwych metod przeszukiwania była umieszczona tylko w klasach wywiedzionych.
