using System;

namespace ejercicio_genetico
{
    class Genetico
    {
        private const int tam_individuo = 8;
        private int tam_poblacion, tam_muestra, num_generaciones;
        private double porc_mutacion, porc_elitismo;
        private Random aleatorio;
        private int[][] poblacion;
        private double[] fitness;

        public Genetico(int t_p, int t_m, int n_g, double p_m, double p_e)
        {
            this.tam_poblacion = t_p;
            this.tam_muestra = t_m;
            this.num_generaciones = n_g;
            this.porc_mutacion = p_m;
            this.porc_elitismo = p_e;
            this.poblacion = new int[this.tam_poblacion][];
            this.fitness = new double[this.tam_poblacion];
        }

        public void Algoritmo()
        {
            int[][] nueva_generacion = new int[this.tam_poblacion][];
            int[][] muestra, padres, hijos, sobrevivientes;

            int cant_sobrevivientes = (int)(this.tam_poblacion * porc_elitismo);
            int cant_mutados = (int)(this.tam_poblacion * porc_mutacion);

            aleatorio = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < this.tam_poblacion; i++) //Generar Poblacion Inicial
            {
                this.poblacion[i] = new int[tam_individuo];

                for (int j = 0; j < tam_individuo; i++)
                    this.poblacion[i][j] = this.aleatorio.Next(0, 2);
            }

            for (int i = 0; i < this.tam_poblacion; i++) //Evaluar la poblacion
                this.fitness[i] = this.EvaluaIndividuo(this.poblacion[i]);

            sobrevivientes = this.SeleccionarSobrevivientes(cant_sobrevivientes);

            for (int i = 0; i < cant_sobrevivientes; i++)
            {
                muestra = this.tomarMuestra();
                padres = this.obtenerPadres(muestra);
                hijos = this.Cruza(padres);
                nueva_generacion[i] = hijos[0];
                if (i < this.tam_poblacion)
                {
                    nueva_generacion[i] = hijos[1];
                    i++;
                }
            }

            int[][] indAMutar = this.tomarMuestraMutacion(cant_mutados, nueva_generacion);

            for (int i = 0; i < cant_mutados; i++)
                indAMutar[i] = this.Mutar(indAMutar[i]);

            poblacion = nueva_generacion;
        }

        private int[] Mutar(int[] v)
        {
            throw new NotImplementedException();
        }

        private int[][] tomarMuestraMutacion(int cant_mutados, int[][] nueva_generacion)
        {
            int[][] muestra = new int[cant_mutados][];

            for (int i = 0; i < cant_mutados; i++)
            {
                int pos = this.aleatorio.Next(this.tam_poblacion);
                muestra[i] = nueva_generacion[pos];
            }

            return muestra;
        }

        private int[][] Cruza(int[][] padres)
        {
            int[][] hijos = new int[2][];
            int[] padre1 = padres[0], padre2 = padres[1];
            bool p = true;

            hijos[0] = new int[tam_individuo];
            hijos[0] = new int[tam_individuo];

            for (int col = 0; col < tam_individuo; col++)
            {
                if (p)
                {
                    hijos[0][col] = padres[0][col];
                    hijos[1][col] = padres[1][col];
                }
                else
                {
                    hijos[0][col] = padres[1][col];
                    hijos[1][col] = padres[0][col];
                }
            }

            return hijos;
        }

        private int[][] obtenerPadres(int[][] muestra)
        {
            int[][] padres = new int[2][];

            double[] fit = new double[this.tam_muestra];

            for (int i = 0; i < this.tam_muestra; i++)
                fit[i] = this.EvaluaIndividuo(muestra[i]);

            int[] posicion_padres = new int[2];

            for (int i = 0; i < 2; i++)
            {
                int pos_mejor = 0;
                double mejor = fit[pos_mejor];

                for (int j = 0; j < this.tam_muestra; j++)
                {
                    if (fit[j] < mejor)
                    {
                        pos_mejor = j;
                        mejor = fit[pos_mejor];
                    }
                }
                posicion_padres[i] = pos_mejor;
                fit[posicion_padres[i]] = double.MaxValue;
            }
            padres[0] = muestra[posicion_padres[0]];
            padres[0] = muestra[posicion_padres[0]];

            return padres;
        }

        private int[][] tomarMuestra()
        {
            int[][] m = new int[this.tam_muestra][];

            for (int i = 0; i < this.tam_muestra; i++)
            {
                int pos = this.aleatorio.Next(0, this.tam_poblacion);
                m[i] = this.poblacion[pos];
            }

            return m;
        }

        private double EvaluaIndividuo(int[] valor)
        {
            string val = "" + valor[0] + valor[1] + valor[2] + valor[3] + valor[4] + valor[5] + valor[6] + valor[7];

            int numero = Convert.ToInt32(val, 2);

            double resultado = Math.Sin(Math.PI * numero / 256);

            return resultado;
        }

        private int[][] SeleccionarSobrevivientes(int ind_sobrevivientes)
        {
            int[][] s = new int[ind_sobrevivientes][];

            for (int i = 0; i < ind_sobrevivientes; i++)
            {
                int mejor_pos = 0;
                double mejor_fit = this.fitness[mejor_pos];

                for (int j = 1; j < this.tam_poblacion; j++)
                {
                    if (this.fitness[j] < mejor_fit)
                    {
                        mejor_pos = j;
                        mejor_fit = this.fitness[mejor_pos];
                    }
                }
                s[i] = this.poblacion[mejor_pos];
                this.fitness[mejor_pos] = double.MaxValue;
            }
            return s;
        }
    }
}
