#include <stdio.h>
#include <stdbool.h>
#define n 5

bool visit(char maze[][n], int route[][n], int originX, int originY) {
    for(int i=0; i<4; i++) {
        if (maze[i][4] == 'r') {
            if (maze[i - 1][4] != 'r' && i-1>=0){
                if(maze[i][3] != 'r' || maze[i+1][4]!='r' ) maze[i][4] = 'w';
            }
            else if(maze[i - 1][4] == 'r' && i-1>=0){
                if(maze[i][3] != 'r' && maze[i+1][4]!='r') maze[i][4] = 'w';
            }
            if(i==0){
                if (maze[i + 1][4] != 'r' || maze[i][3]!='r') maze[i][4] = 'w';
            }
        }
        if (maze[4][i] == 'r') {
            if (maze[4][i - 1] != 'r' && i-1>=0){
                if(maze[4][i + 1] != 'r' || maze[3][i] != 'r') maze[4][i] = 'w';
            }
            else if(maze[4][i - 1] == 'r' && i-1>=0){
                if(maze[4][i + 1] != 'r' && maze[3][i] != 'r') maze[4][i] = 'w';
            }
            if (i==0){
                if (maze[4][i + 1] != 'r' || maze[3][i]!='r') maze[4][i] = 'w';
            }
        }
    }
    for(int j=3;j>0;j--) {
        for (int i = 0; i < 4; i++) {
            if (maze[i][j] == 'r') {
                if (maze[i][j+1] != 'r' && maze[i + 1][j] != 'r' && maze[i - 1][j] != 'r' && i - 1 >= 0)maze[i][j] = 'w';
                if(i==0){
                    if (maze[i + 1][j] != 'r' && maze[i][j+1] != 'r')maze[i][j] = 'w';
                }
            }
            if (maze[j][i] == 'r') {
                if (maze[j][i - 1] != 'r' && maze[j][i + 1] != 'r' && maze[j+1][i] != 'r' && i - 1 >= 0)maze[j][i] = 'w';
                if(i==0){
                    if (maze[j][i + 1] != 'r' && maze[j+1][i] != 'r')maze[j][i] = 'w';
                }
            }
        }
    }
    for(int i=4; i>0; i--) {
        if (maze[i][0] == 'r') {
            if (maze[i-1][0]!='r' && i + 1 <= n){
                if(maze[i + 1][0] != 'r' || maze[i][1] != 'r') maze[i][0] = 'w';
            }
            else if(maze[i-1][0]=='r' && i + 1 <= n){
                if(maze[i + 1][0] != 'r' && maze[i][1] != 'r') maze[i][0] = 'w';
            }
            if (i==4)  {
                if (maze[i - 1][0] != 'r'||maze[i][1]!='r') maze[i][0] = 'w';
            }
        }
        if (maze[0][i] == 'r') {
            if (maze[0][i - 1] != 'r' && i + 1 <= n){
                if(maze[1][i] != 'r' || maze[0][i + 1] != 'r') maze[0][i] = 'w';
            }
            else if(maze[0][i - 1] == 'r' && i + 1 <= n){
                if(maze[1][i] != 'r' && maze[0][i + 1] != 'r') maze[0][i] = 'w';
            }
            if (i==4){
                if (maze[0][i - 1] != 'r'||maze[1][i]!='r') maze[0][i] = 'w';
            }
        }
    }
    for(int j=1;j<4;j++) {
        for (int i = 4; i > 0; i--) {
            if (maze[i][j] == 'r') {
                if (maze[i + 1][j] != 'r' && maze[i - 1][j] != 'r' && maze[i][j-1] != 'r' && i + 1 <= n)maze[i][j] = 'w';
                if (i==4){
                    if (maze[i-1][j] != 'r' && maze[i][j-1]!= 'r')maze[i][j] = 'w';
                }
            }
            if (maze[j][i] == 'r') {
                if (maze[j][i - 1] != 'r' && maze[j][i + 1] != 'r' && maze[j-1][i] != 'r' && i + 1 <= n)maze[j][i] = 'w';
                if (i==4){
                    if (maze[j][i - 1] != 'r' && maze[j-1][i] != 'r')maze[j][i] = 'w';
                }
            }
        }
    }
    route[originY][originX]=1;
    if(maze[originY][originX+1]=='r'&& route[originY][originX+1]!=1 && originX+1<5){
        originX++;
        return visit(maze,route,originX,originY);
    }
    else if(maze[originY+1][originX]=='r' && route[originY+1][originX]!=1 && originY+1<5){
        originY++;
        return visit(maze,route,originX,originY);
    }
    else if(maze[originY-1][originX]=='r'&& route[originY-1][originX]!=1 && originY-1>=0){
        originY--;
        return visit(maze,route,originX,originY);
    }
    else if(maze[originY][originX-1]=='r'&& route[originY][originX-1]!=1 && originX-1>=0){
        originX--;
        return visit(maze,route,originX,originY);
    }
    else if(originX==4 && originY==4) return true;
    else return false;
}

int main(void) {
    char maze[n][n];
    int route[n][n];
    for (int i=0; i<n; i++) {
        for (int j=0; j<n; j++) {
            route[i][j]=0;
            scanf("%c", &maze[i][j]);
            getchar();
        }
    }
    if (visit(maze, route, 0, 0)) { // (0,0) is a starting point
        for (int i=0; i<n; i++) {
            for (int j=0; j<n; j++)
                printf("%d ", route[i][j]);
            printf("\n");
        }
    } else {
        printf("Can't find the exit!");
    }
    return 0;
}