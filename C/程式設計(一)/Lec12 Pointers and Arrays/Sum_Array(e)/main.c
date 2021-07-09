#include <stdio.h>

void star(int* arr, int* result) {
    int *p;
    *result = 0;
    p = &arr[0];
    while ( p <= &arr[4]) {
        *result += *p++;
    }
}

int main()
{
    int arr[5], result;
    for(int i=0; i<5; i++)
        scanf("%d", &arr[i]);

    star(arr, &result);

    printf("%d", result);

    return 0;
}
