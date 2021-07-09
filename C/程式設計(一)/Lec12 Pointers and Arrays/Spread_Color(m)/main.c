#include <stdio.h>
#define M 5
#define N 8
char colors[4] = {'R', 'G', 'B', 'X'};   // Red, Green, Blue, Empty

void spread(char* graph, int row, int col){
    char c;
    int i;
    c=graph[col+8*row];
    for(i=1;i<(N-col);i++){
        if(graph[col+8*row+i]=='X'||graph[col+8*row+i]== c) graph[col+8*row+i]=c;
        else break;
    }
    for(i=1;i<=col;i++){
        if(graph[col+8*row-i]=='X'||graph[col+8*row-i]== c) graph[col+8*row-i]=c;
        else break;
    }
    for(i=1;i<=row;i++){
        if(graph[col+8*(row-i)]=='X'||graph[col+8*(row-i)]== c) graph[col+8*(row-i)]=c;
        else break;
    }
    for(i=1;i<(M-row);i++){
        if(graph[col+8*(row+i)]=='X'||graph[col+8*(row+i)]== c) graph[col+8*(row+i)]=c;
        else break;
    }
}

int main(void) {
    char graph[M][N];
    int row, col;

    for(int i = 0; i < M; i++) {
        for(int j = 0; j < N; j++)
            scanf("%c", &graph[i][j]);
        getchar();      // Ignore '\n'
    }
    scanf("%d %d", &row, &col);    // Starting position

    spread(&graph[0][0], row, col);

    // Print out the spreading result
    for(int i = 0; i < M; i++) {
        for(int j = 0; j < N; j++)
            printf("%c", graph[i][j]);
        printf("\n");
    }
    return 0;
}
