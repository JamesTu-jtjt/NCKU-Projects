#include<stdio.h>

int main(){
    int ch,len;
    len=0;
    while(len<=20){
        ch=getchar();
        switch(ch) {
            case 65: {
                printf("C");
                break;
            }
            case 66: {
                printf("R");
                break;
            }
            case 67: {
                printf("W");
                break;
            }
            case 68: {
                printf("Z");
                break;
            }
            case 69: {
                printf("G");
                break;
            }
        }
        len++;
    }
    return 0;
}
