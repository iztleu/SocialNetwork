create table users
(
    id        bigint auto_increment
        primary key,
    email     varchar(500) charset utf8mb3 not null,
    age       int                          null,
    password  text                         not null,
    name      text                         null,
    surname   text                         null,
    floor     text                         null,
    interests text                         null,
    city      text                         null,
    image     text                         null,
    constraint email
        unique (email)
);

create table article
(
    id          varchar(255) charset utf8mb3 null,
    title       text                         not null,
    description text                         null,
    body        text                         null,
    createdat   datetime                     null,
    updatedat   datetime                     null,
    authorid    bigint                       null,
    constraint article_users_null_fk
        foreign key (authorid) references users (id)
);

