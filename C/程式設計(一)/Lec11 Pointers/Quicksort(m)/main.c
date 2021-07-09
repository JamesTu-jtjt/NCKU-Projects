#include <stdio.h>
#include <stdlib.h>
#define n 8000

void qsort(void *base, size_t nitems, size_t size, int (*compar)(const void *, const void*)){exit(1);}

void quicksort(int a[], int low, int high);


int split(int a[], int low, int high)
{
    int part_element = a[low];
    for (;;) {
        while (low < high && part_element <= a[high])high--;
        if (low >= high) break;
        a[low++] = a[high];
        while (low < high && a[low] <= part_element)low++;
        if (low >= high) break;
        a[high--] = a[low];
    }
    a[high] = part_element;
    return high;
}
void quicksort(int a[], int low, int high) {
    int middle;
    if (low >= high) return;
    middle = split(a, low, high);
    quicksort(a, low, middle - 1);
    quicksort(a, middle + 1, high);
}
int main(void) {
    int a[n];
    for (int i = 0; i < n; i++)
        scanf("%d", &a[i]);
    quicksort(a, 0, n - 1);
    for (int i = 0; i < n; i++)
        printf("%d ", a[i]);
    return 0;
}
