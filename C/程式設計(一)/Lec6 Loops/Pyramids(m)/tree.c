#include<stdio.h>

int main(){
    int n, w, i, a, b;
    scanf("%d", &n);
    w=2*n-1;
    for(i=1;i<=n;i++){
        a=n-i;
        b=2*i-1;
        if (a>0){
            while (a>0){
                printf(" ");
                a--;
            }
            while(b>0){
                printf("*");
                b--;
            }

        }
        else if(a==0){
            while(w>0){
                printf("*");
                w--;
            }
        }
        printf("\n");
    }
    return 0;
}
