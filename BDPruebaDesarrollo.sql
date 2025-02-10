PGDMP  9            	        }            PruebaDesarrollo    17.2    17.2 $               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            !           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            "           1262    16387    PruebaDesarrollo    DATABASE     �   CREATE DATABASE "PruebaDesarrollo" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Colombia.1252';
 "   DROP DATABASE "PruebaDesarrollo";
                     postgres    false            �            1259    16394 
   Inventario    TABLE     �   CREATE TABLE public."Inventario" (
    "Id" integer NOT NULL,
    "IdProducto" integer NOT NULL,
    "Cantidad" integer NOT NULL,
    "IdUsuario" integer NOT NULL,
    "ProductoId" integer DEFAULT 0 NOT NULL
);
     DROP TABLE public."Inventario";
       public         heap r       postgres    false            �            1259    16393    Inventario_Id_seq    SEQUENCE     �   ALTER TABLE public."Inventario" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Inventario_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    219            �            1259    16400    Movimientos    TABLE     (  CREATE TABLE public."Movimientos" (
    "Id" integer NOT NULL,
    "IdProducto" integer NOT NULL,
    "IdTipo" integer NOT NULL,
    "Cantidad" integer NOT NULL,
    "Fecha" timestamp with time zone NOT NULL,
    "IdUsuario" integer NOT NULL,
    "TipoMovimientoId" integer DEFAULT 0 NOT NULL
);
 !   DROP TABLE public."Movimientos";
       public         heap r       postgres    false            �            1259    16399    Movimientos_Id_seq    SEQUENCE     �   ALTER TABLE public."Movimientos" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Movimientos_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    221            �            1259    16406 	   Productos    TABLE     ,  CREATE TABLE public."Productos" (
    "Id" integer NOT NULL,
    "Nombre" text NOT NULL,
    "Descripcion" text NOT NULL,
    "Codigo" text NOT NULL,
    "FechaCreacion" timestamp with time zone NOT NULL,
    "FechaModificacion" timestamp with time zone NOT NULL,
    "IdUsuario" integer NOT NULL
);
    DROP TABLE public."Productos";
       public         heap r       postgres    false            �            1259    16405    Productos_Id_seq    SEQUENCE     �   ALTER TABLE public."Productos" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Productos_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    223            �            1259    16430    TipoMovimiento    TABLE     e   CREATE TABLE public."TipoMovimiento" (
    "Id" integer NOT NULL,
    "Descripcion" text NOT NULL
);
 $   DROP TABLE public."TipoMovimiento";
       public         heap r       postgres    false            �            1259    16429    TipoMovimiento_Id_seq    SEQUENCE     �   ALTER TABLE public."TipoMovimiento" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."TipoMovimiento_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    227            �            1259    16414    Usuarios    TABLE     �   CREATE TABLE public."Usuarios" (
    "Id" integer NOT NULL,
    "Nombre" text NOT NULL,
    "Password" text NOT NULL,
    "FechaCreacion" timestamp with time zone NOT NULL
);
    DROP TABLE public."Usuarios";
       public         heap r       postgres    false            �            1259    16413    Usuarios_Id_seq    SEQUENCE     �   ALTER TABLE public."Usuarios" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Usuarios_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    225            �            1259    16388    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap r       postgres    false                      0    16394 
   Inventario 
   TABLE DATA           a   COPY public."Inventario" ("Id", "IdProducto", "Cantidad", "IdUsuario", "ProductoId") FROM stdin;
    public               postgres    false    219   ,                 0    16400    Movimientos 
   TABLE DATA           {   COPY public."Movimientos" ("Id", "IdProducto", "IdTipo", "Cantidad", "Fecha", "IdUsuario", "TipoMovimientoId") FROM stdin;
    public               postgres    false    221   5,                 0    16406 	   Productos 
   TABLE DATA           �   COPY public."Productos" ("Id", "Nombre", "Descripcion", "Codigo", "FechaCreacion", "FechaModificacion", "IdUsuario") FROM stdin;
    public               postgres    false    223   �,                 0    16430    TipoMovimiento 
   TABLE DATA           ?   COPY public."TipoMovimiento" ("Id", "Descripcion") FROM stdin;
    public               postgres    false    227   I-                 0    16414    Usuarios 
   TABLE DATA           Q   COPY public."Usuarios" ("Id", "Nombre", "Password", "FechaCreacion") FROM stdin;
    public               postgres    false    225   z-                 0    16388    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public               postgres    false    217   �-       #           0    0    Inventario_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Inventario_Id_seq"', 1, false);
          public               postgres    false    218            $           0    0    Movimientos_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Movimientos_Id_seq"', 1, false);
          public               postgres    false    220            %           0    0    Productos_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Productos_Id_seq"', 1, false);
          public               postgres    false    222            &           0    0    TipoMovimiento_Id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."TipoMovimiento_Id_seq"', 1, false);
          public               postgres    false    226            '           0    0    Usuarios_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Usuarios_Id_seq"', 1, false);
          public               postgres    false    224            u           2606    16398    Inventario PK_Inventario 
   CONSTRAINT     \   ALTER TABLE ONLY public."Inventario"
    ADD CONSTRAINT "PK_Inventario" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."Inventario" DROP CONSTRAINT "PK_Inventario";
       public                 postgres    false    219            x           2606    16404    Movimientos PK_Movimientos 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Movimientos"
    ADD CONSTRAINT "PK_Movimientos" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."Movimientos" DROP CONSTRAINT "PK_Movimientos";
       public                 postgres    false    221            z           2606    16412    Productos PK_Productos 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Productos"
    ADD CONSTRAINT "PK_Productos" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Productos" DROP CONSTRAINT "PK_Productos";
       public                 postgres    false    223            ~           2606    16436     TipoMovimiento PK_TipoMovimiento 
   CONSTRAINT     d   ALTER TABLE ONLY public."TipoMovimiento"
    ADD CONSTRAINT "PK_TipoMovimiento" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."TipoMovimiento" DROP CONSTRAINT "PK_TipoMovimiento";
       public                 postgres    false    227            |           2606    16420    Usuarios PK_Usuarios 
   CONSTRAINT     X   ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Usuarios" DROP CONSTRAINT "PK_Usuarios";
       public                 postgres    false    225            r           2606    16392 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public                 postgres    false    217            s           1259    16422    IX_Inventario_ProductoId    INDEX     [   CREATE INDEX "IX_Inventario_ProductoId" ON public."Inventario" USING btree ("ProductoId");
 .   DROP INDEX public."IX_Inventario_ProductoId";
       public                 postgres    false    219            v           1259    16437    IX_Movimientos_TipoMovimientoId    INDEX     i   CREATE INDEX "IX_Movimientos_TipoMovimientoId" ON public."Movimientos" USING btree ("TipoMovimientoId");
 5   DROP INDEX public."IX_Movimientos_TipoMovimientoId";
       public                 postgres    false    221                       2606    16423 -   Inventario FK_Inventario_Productos_ProductoId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Inventario"
    ADD CONSTRAINT "FK_Inventario_Productos_ProductoId" FOREIGN KEY ("ProductoId") REFERENCES public."Productos"("Id") ON DELETE CASCADE;
 [   ALTER TABLE ONLY public."Inventario" DROP CONSTRAINT "FK_Inventario_Productos_ProductoId";
       public               postgres    false    219    4730    223            �           2606    16438 :   Movimientos FK_Movimientos_TipoMovimiento_TipoMovimientoId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Movimientos"
    ADD CONSTRAINT "FK_Movimientos_TipoMovimiento_TipoMovimientoId" FOREIGN KEY ("TipoMovimientoId") REFERENCES public."TipoMovimiento"("Id") ON DELETE CASCADE;
 h   ALTER TABLE ONLY public."Movimientos" DROP CONSTRAINT "FK_Movimientos_TipoMovimiento_TipoMovimientoId";
       public               postgres    false    227    4734    221                  x�3�4�44\F�F��f@�W� 0I]            x�u���0��x�.�16�t�9J�:��F|�x���y`��8y<d�pT'���~|����*�_No\ڗ��8xА���8	�z�zہ9��%�5���r��n�rn#Ƿ�O&;�V&4_�I���5�         u   x�3�t
��t,*ʯRH�I�K�W050PH/�4�4202�50�5�T04�22�26�3�4�50�'e�e��������铚W�������^�3�M���������9��(R�\1z\\\ �'�         !   x�3���K/J-N,�2�t�����2c���� sr�         0   x�3������LL���342�4202�50�5�T00�#]S�=... ��	a         i   x�320250203�0046����,�L�q.JM,I��3�3�2�(1745030�wL/JMO,
J�IL���(�O)M.�GWlfji`	S�Y��_�����W���� ��$     