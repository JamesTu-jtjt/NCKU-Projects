#include <stdio.h>
#define NUM 9

void check_sudoku(int (*grid_p)[NUM]){
    int i, j, k, *n, r, c, b;
    for(i=0;i<NUM;i++){
        for(j=0;j<NUM;j++){
            r=0;
            c=0;
            b=0;
            n = grid_p[i]+j;
            switch(i%3){
                case 0:{
                    switch(j%3){
                        case 0: {
                            if(*(grid_p[i+1]+j+1)==*n||*(grid_p[i+1]+j+2)==*n||*(grid_p[i+2]+j+1)==*n||*(grid_p[i+2]+j+2)==*n) b++;
                            break;
                        }
                        case 1:{
                            if(*(grid_p[i+1]+j-1)==*n||*(grid_p[i+1]+j+1)==*n||*(grid_p[i+2]+j-1)==*n||*(grid_p[i+2]+j+1)==*n) b++;
                            break;
                        }
                        case 2: {
                            if(*(grid_p[i+1]+j-1)==*n||*(grid_p[i+1]+j-2)==*n||*(grid_p[i+2]+j-1)==*n||*(grid_p[i+2]+j-2)==*n) b++;
                            break;
                        }
                    }
                    break;
                }
                case 1:{
                    switch(j%3){
                        case 0: {
                            if(*(grid_p[i-1]+j+1)==*n||*(grid_p[i-1]+j+2)==*n||*(grid_p[i+1]+j+1)==*n||*(grid_p[i+1]+j+2)==*n) b++;
                            break;
                        }
                        case 1:{
                            if(*(grid_p[i-1]+j-1)==*n||*(grid_p[i-1]+j+1)==*n||*(grid_p[i+1]+j-1)==*n||*(grid_p[i+1]+j+1)==*n) b++;
                            break;
                        }
                        case 2: {
                            if(*(grid_p[i-1]+j-1)==*n||*(grid_p[i-1]+j-2)==*n||*(grid_p[i+1]+j-1)==*n||*(grid_p[i+1]+j-2)==*n) b++;
                            break;
                        }
                    }
                    break;
                }
                case 2:{
                    switch(j%3){
                        case 0: {
                            if(*(grid_p[i-1]+j+1)==*n||*(grid_p[i-1]+j+2)==*n||*(grid_p[i-2]+j+1)==*n||*(grid_p[i-2]+j+2)==*n) b++;
                            break;
                        }
                        case 1:{
                            if(*(grid_p[i-1]+j-1)==*n||*(grid_p[i-1]+j+1)==*n||*(grid_p[i-2]+j-1)==*n||*(grid_p[i-2]+j+1)==*n) b++;
                            break;
                        }
                        case 2: {
                            if(*(grid_p[i-1]+j-1)==*n||*(grid_p[i-1]+j-2)==*n||*(grid_p[i-2]+j-1)==*n||*(grid_p[i-2]+j-2)==*n) b++;
                            break;
                        }
                    }
                    break;
                }
            }
            for(k=0;k<9;k++){
                if(*(grid_p[i]+k)==*n) r++;
                if(*(grid_p[k]+j)==*n) c++;
            }
            if(r>=2||c>=2||b>=1) printf("(%d,%d)\n", i, j);
        }
    }
}

int main(void){
    int grid[NUM][NUM]; // sudoku puzzle
    for(int i = 0; i < NUM; ++i){
        for(int j = 0; j < NUM; ++j){
            scanf("%d", &grid[i][j]);
        }
    }
    check_sudoku(grid);
    return 0;
}