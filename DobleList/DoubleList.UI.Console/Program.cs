using DoubleList;
using System.ComponentModel.Design;

var List = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)

    {
        case "1":
            Console.Write("Enter the element to add: ");
            var dataTOAdd = Console.ReadLine();
            if (!String.IsNullOrEmpty(dataTOAdd))
            {
                List.Add(dataTOAdd);
            }
            break;

        case "2":
            Console.WriteLine("List forward: " + List.ShowForward());
           
            break;

        case "3":
            Console.WriteLine("List backward:" + List.ShowBackward());
            break;

        case "5":
            List.SortDescending(); // ordenar descendete 
            Console.WriteLine("List sorted descending.");
            break;

        case "6":
            var modes = List.GetModes();
            if (modes.Any())
            {
                Console.WriteLine("Mode(s):" + String.Join(",",modes));
            }
            else
            {
                Console.WriteLine("No modes.");
            }
            break;

        case "7":
            Console.WriteLine("Ocurrence graph: \n" + List.ShowGraph());

            break;

        case "8":

            Console.WriteLine("Enter the element to check if exists: ");
            var elementExists = Console.ReadLine();
            if (!String.IsNullOrEmpty(elementExists))
            {
                Console.WriteLine("Exists?" + List.Exists(elementExists));
            }
            break;

        case "9":
            Console.WriteLine("Enter remove first occurrent: ");
            var elementToRemoveFirst = Console.ReadLine();
            if (!String.IsNullOrEmpty(elementToRemoveFirst))
            {
                List.RemoveFirstOcurrence(elementToRemoveFirst);
                Console.WriteLine("First occurrence removed.");
            }
            break; 

        case "10":
            Console.WriteLine("Enter remove all occurrences: ");
            var elementToRemoveAll = Console.ReadLine();
            if (!String.IsNullOrEmpty(elementToRemoveAll))
            {
                List.RemoveFirstOcurrence(elementToRemoveAll);
                Console.WriteLine("All occurrences removed.");
            }
                break;

    }
}
while (opc != "0");

string Menu()
{
    Console.WriteLine("\nMenu:"); // Menú
    Console.WriteLine("1. Add"); // Adicionar
    Console.WriteLine("2. Show forward"); // Mostrar hacia adelante
    Console.WriteLine("3. Show backward"); // Mostrar hacia atrás
    Console.WriteLine("5. Sort descending"); // Ordenar descendentemente
    Console.WriteLine("6. Show mode(s)"); // Mostrar la(s) moda(s)
    Console.WriteLine("7. Show graph"); // Mostrar gráfico
    Console.WriteLine("8. Exists"); // Existe
    Console.WriteLine("9. Remove one occurrence"); // Eliminar una ocurrencia
    Console.WriteLine("10. Remove all occurrences"); // Eliminar todas las ocurrencias
    Console.WriteLine("0. Exit"); // Salir
    Console.Write("Choose an option: "); // Elija una opción
    return Console.ReadLine() ?? "0";
}

