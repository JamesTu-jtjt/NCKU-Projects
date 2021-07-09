#include<stdio.h>

int main(){
    int i,j;
    int a[2][32]={0};
    int b[32]={0};
    for(i=0;i<2;i++){
        for(j=0;j<=31;j++){
            scanf("%d",&a[i][j]);
        }
    }
    for(j=31;j>=0;j--){
        b[j]=a[0][j]+a[1][j]+b[j];
        if(j!=0){
            if(b[j]==2){
                b[j]=0;
                b[j-1]=1;
            }
            else if(b[j]==3){
                b[j]=1;
                b[j-1]=1;
            }
        }
        else{
            if(b[j]==2){
                b[j]=0;
            }
            else if(b[j]==3){
                b[j]=1;
            }
        }
    }
    for(i=0;i<32;i++){
        printf("%d ",b[i]);
    }
    return 0;
}

