#include<stdio.h>

int main(){
    int a,b,i,j;
    scanf("%d %d",&a,&b);
    while(a>0 && b>0){
        scanf("%d",&i);
        b-=i;
        if(b<=0){
            printf("A");
            break;
        }
        else{
            scanf("%d",&j);
            a-=j;
            if(a<=0){
                printf("B");
                break;
            }
        }
    }
    return 0;
}
