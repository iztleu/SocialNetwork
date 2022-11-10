create table users
(
    id        bigint auto_increment
        primary key,
    username  text not null,
    email     text not null,
    age       int  null,
    password  text not null,
    name      text null,
    surname   text null,
    floor     text null,
    interests text null,
    city      text null
);

