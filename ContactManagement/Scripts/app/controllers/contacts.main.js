angular
    .module('contacts.main', [])
    .controller('MainCtrl', ['$scope', 'CategoryResource', 'ContactResource',
        function ($scope, CategoryResource, ContactResource) {
            "use strict";

            // Scope Variables
            $scope.categories = [];
            $scope.contacts = [];
            $scope.currentCategory = null;
            $scope.companyFilter = '';
            $scope.editedContact = null;
            $scope.isEditMode = false;

            // Scope Methods
            $scope.setCurrentCategory = setCurrentCategory;
            $scope.isCurrentCategory = isCurrentCategory;
            $scope.createContact = createContact;
            $scope.deleteContact = deleteContact;
            $scope.editContact = editContact;
            $scope.saveContact = saveContact;
            $scope.isSelectedContact = isSelectedContact;
            $scope.isCreating = isCreating;
            
            init();

            function init() {
                loadCategories();
                loadContacts();
            };

            function loadCategories() {
                CategoryResource.getAll()
                    .then(function (data) {
                        $scope.categories = data;
                    });
            };

            function loadContacts() {
                ContactResource.getAll()
                    .then(function (data) {
                        $scope.contacts = data;
                        for (var i = 0; i < $scope.contacts.length; i++) {
                            if ($scope.contacts[i].Birthdate) {
                                $scope.contacts[i].Birthdate = new Date($scope.contacts[i].Birthdate);
                            }
                        }
                    });
            };

            function setCurrentCategory(category) {
                $scope.currentCategory = category;
                $scope.isEditMode = false;
            };

            function isCurrentCategory(category) {
                return $scope.currentCategory !== null && category.CategoryId === $scope.currentCategory.CategoryId;
            };

            function createContact() {
                $scope.editedContact = newContact();
                $scope.isEditMode = true;
            };

            function deleteContact(contact) {
                ContactResource.delete(contact.ContactId)
                    .then(function (data) {
                        // and remove local
                        for (var i = $scope.contacts.length - 1; i >= 0; i--) {
                            if ($scope.contacts[i].ContactId == contact.ContactId) {
                                $scope.contacts.splice(i, 1);
                                break;
                            }
                        }
                });
            };

            function editContact(contact) {
                $scope.editedContact = angular.copy(contact);
                $scope.isEditMode = true;
            };

            function saveContact(contact) {
                if (contact.ContactId == 0) {
                    ContactResource.post(contact)
                        .then(function (data) {
                            $scope.contacts.push(data);
                        });
                } else {
                    ContactResource.put(contact)
                        .then(function (data) {
                            var idx = -1;
                            for (var i = 0; i < $scope.contacts.length && idx == -1; i++) {
                                if ($scope.contacts[i].ContactId == contact.ContactId)
                                    idx = i;
                            };
                            if (idx != -1)
                                $scope.contacts[idx] = contact;
                        });

                    $scope.editedContact = null;
                }

                $scope.isEditMode = false;
            };

            function isSelectedContact(contactId) {
                return $scope.editedContact !== null && $scope.editedContact.ContactId === contactId;
            };

            function isCreating() {
                return angular.isObject($scope.editedContact) &&
                    $scope.editedContact.ContactId == 0;
            };

            function newContact() {
                return {
                    ContactId: 0,
                    FirstName: '',
                    MiddleName: '',
                    LastName: '',
                    Email: '',
                    CompanyName: '',
                    Address: '',
                    WorkPhone: '',
                    CellPhone: '',
                    Category: $scope.currentCategory,
                    Birthdate: null
                };
            };
        }]);