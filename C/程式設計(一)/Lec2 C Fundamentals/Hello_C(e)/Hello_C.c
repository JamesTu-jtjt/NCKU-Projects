#include<stdio.h>

int main() {
    int a, i, j, k, a1;
    scanf("%d", &a);
    int x[a][a];
    a1 /= 2;
    x[0][a1] = 1;
    k = 0;
    while (k < a) {
        if (j % a == 1) k++;
        for (i = 0; i < (a * a); i++) {
            for (j = (a * a); j > 0; j--) {
                x[j % a + k][(a1 + j % a) % a] = i + 1;
            }
        }
    }
    for (i = 0; i < a; i++) {
        for (j = 0; j < a; j++) printf("%d ", x[i][j]);
    }
    return (0)
}

