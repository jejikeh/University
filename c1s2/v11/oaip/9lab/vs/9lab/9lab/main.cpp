﻿#include <iostream>

// g++ *.cpp  .\modules\quene\quene.cpp && .\a.exe

struct node {
    int data;
    node* next;
    node(int p_data, node* p_next) {
        data = p_data; next = p_next;
    }
};

struct l {
    node* root;
    l(int data) {
        root = new node(data, nullptr);
    }
    node* get_last(node* temp) {
        if (temp->next) {
            get_last(temp->next);
        }
        else {
            return temp;
        }
    }
    void insert_node(int data) {
        if (!root) {
            root = new node(data, nullptr);
        }
        else {
            node* last = get_last(root);
            node* new_node = new node(data, nullptr);
            last->next = new_node;
        }
    }
    void print_l() {
        node* temp = root;
        while (temp) {
            std::cout << temp->data << " "; temp = temp->next;
        }
    }

    void remove_node() {
        node* new_root = root->next;
        delete root;
        root = new_root;
    }

    void done_quene() {
        while (root) {
            remove_node();
        }
        delete root;
    }
};

void load_to_array(node* n[], l* quene, int length_nodes) {
    for (node* i = quene->root; i != nullptr; i = i->next) {
        n[length_nodes] = new node(i->data, i->next);
        //length_nodes++;
    }
    //return length_nodes;
}

void load_to_struct(node* n[], l* quene, int length_nodes) {
    for (int i = 0; i < length_nodes; i++) {
        //std::cout << nodes[i]->data << " ";
        quene->insert_node(n[i]->data);
    }
}

//pnyavy 9 lab
void swap(node* n[], int x, int y) {
    node* temp = n[y];
    n[y] = n[x];
    n[x] = temp;
}

void sort_array_bublle(node* n[], int length_array) { // сортировка масиива 
    for (int i = 0; i < length_array; i++) { // каждый узел сравниваем с каждым узлом
        for (int k = 0; k < length_array - i - 1; k++) {
            if (n[k]->data > n[k + 1]->data) { // если узел который меньше другога узла стоит позже большего, то меняем их местами 
                swap(n, k, k + 1);
            }
        }
    }
}

int linear_search(node* n[], int value, int length_array, int start) {
    for (int i = start; i < length_array; i++) {
        if (n[i]->data == value) {
            return i;
        }
    }
    return -1;
}

int linear_double_search(node* n[], int value, int length_array) { // проверяется середина
    int count = 0;
    int ind = -1;
    while ((ind = linear_search(n, value, length_array, ind + 1)) != -1) {
        count++;
    }
    return count;
}

int main() {


    l* quene = new l(0); // структура данных
    quene->insert_node(2);
    quene->insert_node(3);
    quene->insert_node(2);
    quene->insert_node(100);
    quene->insert_node(100);
    //quene->insert_node(5);
    //quene->print_l();
    //quene->print_l();

    const int length_nodes = 10;
    node* nodes[length_nodes]; // динамический массив узлов

    load_to_array(nodes, quene, length_nodes); // устанавливаем длинну динамического массива равную количествам нод в структуре
    //quene->print_l();
    quene->done_quene(); // удаление структуры

    sort_array_bublle(nodes, length_nodes);
    load_to_struct(nodes, quene, length_nodes);

    quene->print_l();

    std::cout << linear_double_search(nodes, 2, length_nodes);
}