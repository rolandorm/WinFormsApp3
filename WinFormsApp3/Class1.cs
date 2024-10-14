using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class ClassCM
    {
        public List<List<int>> AleatorioCuadradoMedio(int semilla, int cantidad_max)
        {
            List<int> listaAleatorios = new List<int>();
            List<List<int>> listaAleatoriosTotal = new List<List<int>>();
            List<int> cuadrados = new List<int>();
            List<int> centros = new List<int>();
            List<int> primerosLista = new List<int>();
            List<int> ultimosLista = new List<int>();
            listaAleatorios.Add(semilla);
            int contador = 0;
            while ((contador < cantidad_max) && (listaAleatorios[listaAleatorios.Count - 1] != 0))
            {
                int last = listaAleatorios[listaAleatorios.Count - 1];
                int squared = last * last;

                //agregar squared a cuadrados
                cuadrados.Add(squared);

                string squared_str = Convert.ToString(squared);
                if (squared_str.Length < 3)
                {
                    last = squared;
                    listaAleatorios.Add(last);
                    continue;
                }

                // quitar extremos
                string center_str = squared_str.Substring(1, squared_str.Length - 2);
                int center_int = Convert.ToInt32(center_str);

                if (center_int == 0)
                {
                    break;
                }

                // obtener longitud N de la semilla
                int longitud = Convert.ToString(semilla).Length;

                //si center_int convertido a string tiene longitud menor a la de la semilla, hacer break
                if (Convert.ToString(center_int).Length < longitud)
                {
                    break;
                }

                //agregar center_int a centros
                centros.Add(center_int);

                if (listaAleatorios.IndexOf(center_int) != -1)
                {
                    break;
                }

                // obtener longitud N de la semilla
                //int longitud = Convert.ToString(semilla).Length;
                // tomar 'longitud' primeros dígitos
                int primeros = Convert.ToInt32(Convert.ToString(center_int).Substring(0, longitud));
                //agregar primeros a primerosLista
                primerosLista.Add(primeros);

                // tomar 'longitud' últimos dígitos
                int ultimos = Convert.ToInt32(Convert.ToString(center_int).Substring(Convert.ToString(center_int).Length - longitud, longitud));
                //agregar ultimos a ultimosLista
                ultimosLista.Add(ultimos);

                // last es el elemento que no sea cero entre 'primeros' y 'ultimos'
                if (primeros != 0)
                {
                    last = primeros;
                }
                else
                {
                    last = ultimos;
                }
                contador += 1;
                //agregar last a listaAleatorios
                listaAleatorios.Add(last);

            }
            //tomar cada longitud de listaAleatorios, cuadrados, centros, primerosLista, ultimosLista, conseguir la longitud mínima y tomar esa cantidad de elementos de cada lista
            int min = new List<int> { listaAleatorios.Count, cuadrados.Count, centros.Count, primerosLista.Count, ultimosLista.Count }.Min();
            listaAleatorios = listaAleatorios.GetRange(0, min);
            cuadrados = cuadrados.GetRange(0, min);
            centros = centros.GetRange(0, min);
            primerosLista = primerosLista.GetRange(0, min);
            ultimosLista = ultimosLista.GetRange(0, min);


            listaAleatoriosTotal.Add(listaAleatorios);
            listaAleatoriosTotal.Add(cuadrados);
            listaAleatoriosTotal.Add(centros);
            listaAleatoriosTotal.Add(primerosLista);
            listaAleatoriosTotal.Add(ultimosLista);

            // // borrar último elemento de listaAleatorios
            // listaAleatorios.RemoveAt(listaAleatorios.Count - 1);

            return listaAleatoriosTotal;
        }
    }
}
