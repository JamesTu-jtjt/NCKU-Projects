#include<stdio.h>

int main() {
    double r,b;
    int n, i, a;
    scanf("%lf %d", &r, &n);
    b = 1;
    for (i = 0; i < n; i++) {
        b *= r;
    }
    a=b;
    printf("%d", a);
    return 0;
}
