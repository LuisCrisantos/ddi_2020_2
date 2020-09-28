using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Problems : MonoBehaviour
{
    void Start()
    {
            int[] nums = {8,1,2,2,3};
            //int [] nums = {1,1,0,3,7};
            //int[] nums = {5,9,4,2,7};
            int[] chicos;
            int i;
            chicos = Menores(nums);

            for(i=0; i<chicos.Length; i++)
            {
                Debug.Log(chicos[i]+" ");
            }

    }

    public static int[] Menores(int[] array)
        {
            int i, j, cont;									
            int[] menores = new int[array.Length];		//3
														//    n+1	n
            for (i = 0; i < array.Length; i++)			//1 + S 1  +S 2
            {											//    i=0	i=0

														//n
				cont = 0;								//S 1
														//i=0

														//n     n   n+1    n   n
				for (j = 0; j < array.Length; j++)      //S 1 + S   S  1 + S   S   2
                {										//i=0   i=0 j=0    i=0 j=0
                    
				                                        //n   n
					if (array[i] > array[j])			//S   S 3
                    {									//i=0 j=0
					
														//n	  n
						cont++;							//S   S 2
                    }									//i=0 j=0
                }
														//n
                menores[i] = cont;						//S 2
            }											//i=0
            return menores;								//1
        }
}
