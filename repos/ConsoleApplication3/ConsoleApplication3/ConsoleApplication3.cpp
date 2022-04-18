#include "pch.h"
#include <iostream>
#include <string>
#include "App.h"
#include <Windows.h>

using namespace std;

struct Derevo {
	App st;
	Derevo* parent;
	Derevo* left;
	Derevo* right;
};

class Tree {
private:
	Derevo* Root;
	int num;
	Derevo* SearchRemoteNode(float size_on_disk, string name) {
		Derevo* current;
		current = Root;
		while (current) {
			if (size_on_disk > current->st.size_on_disk)
				current = current->right;
			else {
				if (size_on_disk == current->st.size_on_disk) {
					if (name > current->st.name)
						current = current->right;
					else {
						if (name < current->st.name)
							current = current->left;
						return current;
					}
				}
				else
					current = current->left;
			}
		}
		return NULL;
	}
	
	App SearchHeir(Derevo* Node) {
		Derevo* current;
		current = Node->right;
		while (current->left)
			current = current->left;
		App st = current->st;
		Delete(current->st.size_on_disk, current->st.name);
		return st;
	}
	void Unloading(Derevo* root, App* arr, int& i) {
		if (root == NULL)
			return;
		arr[i] = root->st;
		if (root->left != NULL)
			Unloading(root->left, arr, ++i);
		if (root->right != NULL)
			Unloading(root->right, arr, ++i);
	}

public:
	Tree() {
		Root = NULL;
		num = 0;
	}
	int GetSize() {
		return num;
	}
	void Add(App elem) {
		if (Root) {
			Derevo* current, * previous = NULL;
			bool right = true;
			current = Root;
			while (current) {
				previous = current;
				if (elem.size_on_disk > current->st.size_on_disk) {
					current = current->right;
					right = true;
				}
				else {
					if (elem.size_on_disk == current->st.size_on_disk) {
						if (elem.name > current->st.name) {
							current = current->right;
							right = true;
						}
						else {
							if (elem.name < current->st.name) {
								current = current->left;
								right = false;
							}
							if (elem.name == current->st.name) {
								cout << "Приложение с такими параметрами уже в списке" << endl;
								return;
							}
						}
					}
					else {
						current = current->left;
						right = false;
					}
				}
			}
			current = new Derevo();
			current->parent = previous;
			if (right)
				current->parent->right = current;
			else
				current->parent->left = current;
			current->left = NULL;
			current->right = NULL;
			current->st = elem;
		}
		else {
			Root = new Derevo();
			Root->parent = NULL;
			Root->left = NULL;
			Root->right = NULL;
			Root->st = elem;
		}
		cout << "Приложение добавлено" << endl;
		num++;
	}

	void Delete(float size_on_disk, string name) {
		bool deleter = true;
		Derevo* deleteNode;
		deleteNode = SearchRemoteNode(size_on_disk, name);
		if (deleteNode)
		{
			if (deleteNode != Root) 
			{
				if (deleteNode->left == NULL && deleteNode->right == NULL) 
				{
					if (deleteNode->parent->left == deleteNode)
						deleteNode->parent->left = NULL;
					else
						deleteNode->parent->right = NULL;
				}
				if (deleteNode->left != NULL && deleteNode->right == NULL) 
				{
					if (deleteNode->parent->left == deleteNode)
						deleteNode->parent->left = deleteNode->left;
					else
						deleteNode->parent->right = deleteNode->left;
				}
				if (deleteNode->left == NULL && deleteNode->right != NULL)
				{
					if (deleteNode->parent->left == deleteNode)
						deleteNode->parent->left = deleteNode->right;
					else
						deleteNode->parent->right = deleteNode->right;
				}
			}
			else 
			{
				if (deleteNode->left == NULL && deleteNode->right == NULL)
					Root = NULL;
				if (deleteNode->left != NULL && deleteNode->right == NULL) 
					Root = deleteNode->left;
				if (deleteNode->left == NULL && deleteNode->right != NULL) 
					Root = deleteNode->right;
			}
			if (deleteNode->left != NULL && deleteNode->right != NULL) 
			{
				App successor = SearchHeir(deleteNode);
				deleteNode->st = successor;
				deleter = false;
			}
			if (deleter)
			{
				delete deleteNode;
				num--;
			}
			cout << "Приложение удалено" << endl;
		}
		else
			cout << "Приложение найдено" << endl;
	}
	bool Content(float findsize_on_disk) {
		Derevo* current;
		current = Root;
		while (current)
		{
			if (findsize_on_disk > current->st.size_on_disk)
				current = current->right;
			else
			{
				if (findsize_on_disk == current->st.size_on_disk)
				{
					cout << "Приложение уже в списке" << endl;
					return true;
				}
				else
					current = current->left;
			}
		}
		cout << "Приложение не найдено" << endl;
		return false;
	}

	bool Content(float findsize_on_disk, string findname) {
		Derevo* current;
		current = Root;
		while (current) {
			if (findsize_on_disk > current->st.size_on_disk)
				current = current->right;
			else {
				if (findsize_on_disk == current->st.size_on_disk) {
					if (findname > current->st.name)
						current = current->right;
					else {
						if (findname < current->st.name)
							current = current->left;
						if (findname == current->st.name) {
							cout << "Приложение уже существует" << endl;
							return true;
						}
					}
				}
				else
					current = current->left;

			}
		}
		cout << "Приложение не найдено" << endl;
		return false;
	}

	App* Massiv() {
		App* mas = new App[num];
		int nol = 0;
		Unloading(Root, mas, nol);
		return mas;
	}
	~Tree() {
		delete Root;
	}
};

void Set(Tree& Applications) {
	App elem;
	elem.name = "Doodle";
	elem.manufacturer = "Poodle";
	elem.size_on_disk = 280;
	elem.price = 450;
	Applications.Add(elem);

	elem.name = "Doodle";
	elem.manufacturer = "Poodle";
	elem.size_on_disk = 280;
	elem.price = 450;
	Applications.Add(elem);

	elem.name = "Zoom";
	elem.manufacturer = "Flash";
	elem.size_on_disk = 240;
	elem.price = 400;
	Applications.Add(elem);

	elem.name = "Batman";
	elem.manufacturer = "Bat&Man";
	elem.size_on_disk = 290;
	elem.price = 420;
	Applications.Add(elem);
}

void Get(Tree& Applications) {
	App* stu = Applications.Massiv();
	for (int i = 0; i < Applications.GetSize(); i++) {
		cout << "Наименование: " << stu[i].name << endl;
		cout << "Производитель: " << stu[i].manufacturer << endl;
		cout << "Размер на диске: " << stu[i].size_on_disk << endl;
		cout << "Цена: " << stu[i].price << endl;
		cout << endl;
	}
}

int main() {
	setlocale(LC_ALL, "rus");
	Tree Applications;
	Set(Applications);
	cout << endl;
	Get(Applications);
	Applications.Delete(280, "Doodle");
	Applications.Delete(290, "Batman");
	cout << endl;
	Get(Applications);
	Applications.Content(150);
	Applications.Content(280, "Doodle");
	cout << endl;
	system("pause");
	return 0;
}
