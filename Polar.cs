public class Polar
{
    public void LoadPolar(string filePath)
    {
        String input = filePath;

        int num_rows = input.Count(c => c == ' ');
        int num_cols = input.Count(c => c == '\n');

        int i = 0, j = 0;
        double[,] polar = new double[num_rows, num_cols];
        double[,] polar_twa = new double[num_rows, 1];
        double[,] polar_tws = new double[1, num_cols];

        foreach (var row in input.Split('\n'))
        {
            j = 0;

            foreach (var col in row.Trim().Split(' '))
            {
                if (i == 0) { polar_tws[0, j] = double.Parse(col.Trim()); }   // extract tws vector
                if (j == 0) { polar_twa[i, 0] = double.Parse(col.Trim()); }   // extract twa vector
                else { polar[i, j] = double.Parse(col.Trim()); };             // get polar
                j++;
            }
            i++;
        }
    }


    static void Interpolate(double[,] array, int row_multiplier, int col_multiplier)
    {
        int num_rows = 1;
        int num_cols = 1;

        if (array.GetLength(0) > 1) { num_rows = ((array.GetLength(0) - 1) * row_multiplier) + 1; }       // determine number of rows
        if (array.GetLength(1) > 1) { num_cols = ((array.GetLength(1) - 1) * col_multiplier) + 1; }       // determine number of cols

        double[,] array_out = new double[num_rows, num_cols];                                         // initialize output array size

        int j = 0;                                                                                    // initialize j for first loop through i


        for (int i = 0; i < array.GetLength(0) - 1; i++)                                              // loop through first deminsion of array
        {
            //Console.WriteLine(array[i,j]);
            Console.WriteLine(i);
            if (num_rows > 1)                                                                         // if rows are being interpolated
            {
                var step_i = (array[i + 1, j] - array[i, j]) / row_multiplier;                        // find step size 
                for (int ii = 0; ii < row_multiplier; ii++)
                {
                    array_out[(i * row_multiplier) + ii, j] = array[i, j] + (step_i * ii);
                }

                array_out[array_out.GetLength(0) - 1, j] = array[array.GetLength(0) - 1, j];               // add last value in that would get lost
            }

            if (num_cols > 1)                                                                         // if col are being interpolated
            {

                for (j = 0; j < array.GetLength(1) - 1; j++)                                          // loop through first deminsion of array
                {
                    var step_j = (array[i, j + 1] - array[i, j]) / col_multiplier;                        // find step size

                    for (int jj = 0; jj < row_multiplier; jj++)
                    {
                        array_out[i, (j * row_multiplier) + jj] = array[i, j] + (step_j * jj);
                    }
                    array_out[i, array_out.GetLength(1) - 1] = array[i, array.GetLength(1) - 1];   // add last value in that would get lost

                }
            }
        }
    }





}

