<!-- TOC start (generated with https://github.com/derlin/bitdowntoc) -->

- [PersonManagerWPF](#personmanagerwpf)
   * [Functionalities](#functionalities)
      + [Person](#person)
         - [List People](#list-people)
         - [Add Person](#add-person)
         - [Person Profile](#person-profile)
            * [Edit Person](#edit-person)
            * [Delete Person](#delete-person)
            * [See classes of Person](#see-classes-of-person)
   * [Class](#class)
      + [List Classes](#list-classes)
      + [Add](#add)
      + [Delete](#delete)
      + [Class profile](#class-profile)
         - [Teacher Profile](#teacher-profile)
         - [Student Profile](#student-profile)
         - [Add Student](#add-student)
         - [Delete Student](#delete-student)
         - [Edit Class](#edit-class)
   * [Entity-Relationship Diagram](#entity-relationship-diagram)
   * [Problems Faced](#problems-faced)
   * [Repository Content](#repository-content)
   * [Important to know](#important-to-know)

<!-- TOC end -->

<!-- TOC --><a name="personmanagerwpf"></a>
# PersonManagerWPF

Project of the subject of Accessing Data From Program Code of the Software Engineering degree at Algebra University College (Zagreb). The project consist in a person management application. It uses the WPF framework with the Model-View-ViewModel Pattern. As other projects of the Accessing Data From Program Code subject, part of the code is done by the proffesor **Daniel Bele**. For the server and database I use Azure.

<!-- TOC --><a name="functionalities"></a>
## Functionalities

The correct name of the application would be something like school manager, because user are able, not only to manage people information, but also the classes the organization has, an the rellations classes-person.

<!-- TOC --><a name="person"></a>
### Person

<!-- TOC --><a name="list-people"></a>
#### List People

In the app, user is able to list all the people inside the application. User can list all students, employees, teachers and all people. As you can see, when user hovers the email, the image of the person is shown.

<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/92f6b459-f2c9-4465-8885-bf8e794a7fc7">
<img width="437" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/c36572d6-3dfa-4871-a100-941bf6ec7107">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/3325ddd8-9eae-4e79-82f7-c820632adcf3">

<!-- TOC --><a name="add-person"></a>
#### Add Person

The only restriction the user has, is that every texbox should be filled with the correct type (there is also an email checker).

<img width="432" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/2b09d46f-18f0-4c3b-9996-c5432112a10a">
<img width="437" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/64895186-b953-49a8-82fb-b83ebc13df96">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/181b81de-3473-4436-9ba4-5b6d4e503ced">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/407a9b40-7ccf-4134-905c-ffd388b76ab1">


<!-- TOC --><a name="person-profile"></a>
#### Person Profile

By Double Click on an element of the list, user will see al the atributes of the selected-person. In that view the user can edit, delete or see the classes of the person. In every view but the list people view, there is a button to go back.

<img width="437" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/f3ac6cd1-c97d-4c91-b9b0-1985505bc69c">

<!-- TOC --><a name="edit-person"></a>
##### Edit Person

In the profile person view and in the list people view the user can edit the selected person.

<img width="433" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/dfd5e4ff-2669-4116-b8be-65c8df227c52">
<img width="432" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/6e9fc363-73af-4b72-b59f-feef869ab591">
<img width="436" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/2da298fe-7270-43a7-8c93-ac15f4bf5966">

<!-- TOC --><a name="delete-person"></a>
##### Delete Person

In the profile view user is also able to delete selected person. Can also be done through the list people view.

<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/3ca61b23-a69c-4863-a894-2d0915874b48">

If the teacher is teaching a class, user can not delete it. With the user does no happend the same.

<img width="412" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/f9691fe8-5b2e-4a1c-9540-b2a9955c80ab">

Once the teacher doesn't have any class can be deleted.

<!-- TOC --><a name="see-classes-of-person"></a>
##### See classes of Person

Only in the profile view, the user can see the classes where the user is enroll or the teacher is teaching.

<img width="434" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/6aa9161b-e40c-4519-bd99-bfce8f47c930">
<img width="433" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/2e73536d-a5fe-4e52-b9c7-e9b712a9dd1c">
<img width="438" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/85a429e6-68aa-4767-a08d-8c0ac8ad1531">

As you may notice, there is a diferent view between listing the classes of a teacher and a student:
  - From teacher, user can manage classes as normally (adding and deleting from general).
  - From student, user can add the student to a existing or delete from one. The next images show how it works only for this "section".

<img width="437" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/2cd56b0c-2b69-4134-a709-231f3231b2a4">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/5e4b547a-e552-42b6-ba42-85cd86d8c8b9">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/d8314904-e525-4bd2-9114-ac1130c26a8e">
<img width="434" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/3acc45f7-007e-4c9d-9512-081fdd4af978">

<img width="437" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/84a62615-d64e-47bb-8a52-fdcd66316063">
<img width="433" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/404097ee-3ef7-4dd9-b251-51c9f3d5cf24">

<!-- TOC --><a name="class"></a>
## Class

By clicking on the button "classes" in the list peopel view, the user can access to this "section".
<!-- TOC --><a name="list-classes"></a>
### List Classes

In this view the user can go back to the list people view, see the selected class profile, add new class and delete one.

<img width="432" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/7f61a4a2-b989-4dfd-8ce9-05b1c7e5edcf">

<!-- TOC --><a name="add"></a>
### Add

By clicking the button `Teacher` the user can select the teacher for the new class.

<img width="434" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/eb19d9d7-720b-4760-971d-3f089c3b6bea">

<!-- TOC --><a name="delete"></a>
### Delete

There is no retrictions for deleting.

<img width="436" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/616b589a-36ba-450e-a9f2-4a15021031bb">

<!-- TOC --><a name="class-profile"></a>
### Class profile

By double clicking on a class in the table list, the user will be able to see the profile of a class.

<img width="436" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/aee4d400-ba58-4196-84f0-f24a798bc9a5">

<!-- TOC --><a name="teacher-profile"></a>
#### Teacher Profile

By clicking the button `Teacher` the user can see the profile of the teacher. The user won't be able to edit, delete or see the classes of the person, if not we colud enter in an infinite loop.

<img width="431" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/341a9d5e-5360-4fbe-a47d-e5dae68358a3">

<!-- TOC --><a name="student-profile"></a>
#### Student Profile

By double clicking in a student of the table list the profile of the student, with the same restrictions as in the view teacher profile.

<img width="436" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/fcf9647a-f60a-4749-af11-1a67a9451508">

<!-- TOC --><a name="add-student"></a>
#### Add Student

The user can not select a student that its already in the class.

<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/325e8add-c3d3-4f13-97aa-8c90f9e959a8">
<img width="433" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/9ad4a44f-d20d-4b47-a238-30ffc3c408c3">
<img width="407" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/49777cac-3626-479b-a836-02f5c3eee5b5">
<img width="433" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/afe463c0-e14a-494d-b73b-03a805c157ea">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/bccc33da-6f91-4366-aeba-0fafc869c771">

<!-- TOC --><a name="delete-student"></a>
#### Delete Student

<img width="436" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/6f358b26-f94b-40f0-8644-4331ccb73da1">
<img width="436" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/3a819bbc-2955-427b-87e3-3b89111d2e1d">

<!-- TOC --><a name="edit-class"></a>
#### Edit Class

<img width="438" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/9f4a79b5-182c-4b7c-b09f-263088f8b0db">
<img width="435" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/cbe190ce-c931-4d0d-acca-2db0f447239b">
<img width="433" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/e805f540-c6fe-4479-b055-6c86cb0a82cf">
<img width="434" alt="image" src="https://github.com/MrCharlesSG/PersonManagerWPF/assets/94635721/d1f43da1-3a9e-48e3-a2c9-5c047d536be6">

<!-- TOC --><a name="entity-relationship-diagram"></a>
## Entity-Relationship Diagram

<!-- TOC --><a name="problems-faced"></a>
## Problems Faced

I was a bit lost until I finally understood the Model-View-ViewModel pattern, which I think is very powerfull due to its is easier to implements observers (in my experience). Connecting to the database and creating the scripts was also quite a mess, although I already knew how to make procedures, I had to refresh my mind because has been a year since I didn't do anything. 

My bigest problem was the edit part. Although it updates me the data base, it didn't update me the ViewModel. As i didn't know how to fixed (becouse I was literally changing the element of the observable list) and I was I solved in a simple way but very effective. Instead of just going back in the frames (that was what I was doing), I redirect to the list classes/people view wich will get again from the database the classes/people, that if you remember, I was  updating correctly.

<!-- TOC --><a name="repository-content"></a>
## Repository Content

This repository contains:

- Code of the project
- This Readme
- All the scripts for the Data Base. As it was my first project making "real" scripts for a data base they are completly desorganized.

<!-- TOC --><a name="important-to-know"></a>
## Important to know

To use the project is important to connect to the database
