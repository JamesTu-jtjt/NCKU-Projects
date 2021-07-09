#include<stdio.h>

int main(){
    int n,x,a;
    scanf("%d %d %d", &n, &x, &a);
    printf("%d",(x+a)%n);
    return 0;
}
