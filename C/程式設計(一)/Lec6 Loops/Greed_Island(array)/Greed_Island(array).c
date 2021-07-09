#include<stdio.h>

int main(){
    char ch, def[2][5]={{'A','B','C','D','E'},{'C','R','W','Z','G'}};
    int i,j;
    j=0;
    while(j<20){
        ch=getchar();
        for(i=0;i<5;i++){
            if(ch==def[0][i])printf("%c",def[1][i]);
        }
        j++;
    }
    return 0;
}
