#include<stdio.h>

int main() {
    int a, i, j, k, a1;
    scanf("%d", &a);
    int x[a][a];
    a1 = a/2;
    k = 0;
    while (k < a) {
        for (i = 0; i < (a * a); i++) {
            j=a*a-i;
            x[(j+2*k) % a][(a1-k +i) % a] = i+1;
            if ((j % a) == 1) k++;
        }
    }
    for (i = 0; i < a; i++) {
        for (j = 0; j < a; j++) {
            printf("%d ", x[i][j]);
            if(j==(a-1)) printf("\n");
        }
    }
    return 0;
}
