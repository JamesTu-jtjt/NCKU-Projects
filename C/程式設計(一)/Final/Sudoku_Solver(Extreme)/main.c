#include <stdio.h>
#include <stdbool.h>

struct element {
    int num;        // 1~9: valid, 0: don't have value yet
    bool can_modify;       // true: white area in the figure, false: gray area in the figure
};

void solve(struct element (*grid_p)[9]);
void print_grid(struct element (*grid_p)[9]) {
    for (int i = 0; i < 9; ++i) {
        for (int j = 0; j < 9; ++j) {
            printf("%d ", grid_p[i][j].num);
        }
        printf("\n");
    }
}

int main(void) {
    struct element grid[9][9];
    char ch;
    for (int i = 0; i < 9; ++i) {
        for (int j = 0; j < 9; ++j) {
            scanf(" %c", &ch);
            if (ch == '.') {    // can_modify assign true, num assign 0
                grid[i][j].num = 0;
                grid[i][j].can_modify = true;
            }
            else {      // value gotten from input, so we can't change this
                grid[i][j].num = ch - '0';
                grid[i][j].can_modify = false;
            }
        }
    }
    solve(grid);
    print_grid(grid);
    return 0;
}

int possibility(struct element (*grid_p)[9], int i, int j, int num){
    int r=(i/3) * 3;
    int c=(j/3) * 3;
    for(int k=0;k<9;k++){
        if((grid_p[i]+k)->num==num) return 0;
        if((grid_p[k]+j)->num==num) return 0;
        if((grid_p[r+(k%3)]+c+(k/3))->num==num) return 0;
    }
    return 1;
}

int checker(struct element (*grid_p)[9], int row, int col){
    if((grid_p[row]+col)->num != 0){
        if((col+1)<9) return checker(grid_p, row, col+1);
        else if((row+1)<9) return checker(grid_p, row+1, 0);
        else return 1;
    }
    else{
        for(int i=1; i<10; i++){
            if(possibility(grid_p, row, col, i)){
                (grid_p[row]+col)->num = i;
                if(checker(grid_p, row, col)) return 1;
                else (grid_p[row]+col)->num = 0;
            }
        }
    }
    return 0;
}

void solve(struct element (*grid_p)[9]) {
    for(int i=0;i<9;i++){
        for(int j=0;j<9;j++) {
            if ((grid_p[i] + j)->can_modify == true) {
                checker(grid_p,i,j);
                break;
            }
        }
    }
}