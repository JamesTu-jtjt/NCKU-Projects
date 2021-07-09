#include<stdio.h>

int main(){
    int n,i;
    scanf("%d \n",&n);
    char a[n];
    for (i = 0; i < n; i++) {
        a[i] = getchar();
    }
    for(i=(n-1);i>=0;i--) {
        printf("%c",a[i]);
    }
    return 0;
}
