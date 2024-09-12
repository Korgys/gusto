# Projet Gusto - Expression du Besoin et Cahier des Charges

## 1. Contexte et objectifs

Gusto est une application mobile destinée aux artisans de l'alimentaire (fromagers, cavistes, charcutiers, etc.). Elle permet de générer des fiches de dégustation personnalisées pour leurs clients. Lorsqu'un client achète un produit ou un ensemble de produits (ex. plateau de fromages), l'artisan peut générer un lien unique, accessible via un QR code. Ce lien renvoie à une fiche de dégustation décrivant les produits, leurs caractéristiques, les conseils de dégustation, et éventuellement des accords mets/vins.

Objectifs de l'application :

- Offrir aux artisans un moyen simple de créer des fiches de dégustation digitales.
- Proposer aux clients une expérience enrichie lors de l'achat de produits alimentaires.
- Faciliter la gestion des produits et des fiches de dégustation pour les artisans.

## 2. Acteurs du projet

Utilisateurs principaux :

- Artisan (utilisateur principal) : Fromagers, cavistes, charcutiers, etc. qui utilisent l'application pour créer des fiches de dégustation.
- Client : Consommateur final qui reçoit et consulte la fiche de dégustation via le QR code fourni par l'artisan.

Autres acteurs :

- Administrateur de l’application : Responsable de la gestion de l'application, des utilisateurs et du bon fonctionnement global (back-office).
- API Externe (API de génération de fiches de dégustation) : Service tiers payant permettant la génération automatique de fiches de dégustation à partir des informations fournies par l'artisan.

## 3. Fonctionnalités attendues

### 3.1 Gestion des fiches de dégustation

- Création de fiches personnalisées : L’artisan doit pouvoir créer une fiche de dégustation en sélectionnant les produits dans une base de données (BD) ou en ajoutant manuellement un produit.
- Description des produits : Chaque produit doit être accompagné d’une description détaillée (origine, caractéristiques gustatives, accord mets-vins, conseils de consommation).
- Génération de QR Code : Une fois la fiche de dégustation créée, un QR code unique est généré pour chaque fiche, accessible pour le client.
- Gestion des produits : L’artisan doit pouvoir ajouter, modifier ou supprimer des produits de sa base de données personnelle.

### 3.2 Interface utilisateur pour les artisans

- Formulaire d'authentification : Interface standard pour créer un compte, se connecter, choisir l'option mot de passe oublié.
- Tableau de bord : Vue d’ensemble des fiches créées, avec accès aux statistiques (nombre de fiches générées, fiches consultées, etc.).
- Formulaire de création : Interface simple permettant de créer une nouvelle fiche en quelques étapes (sélection des produits, génération automatique du texte, personnalisation).
- Historique des fiches : Liste des fiches déjà créées, avec possibilité de les réutiliser ou les modifier.

### 3.3 Consultation des fiches de dégustation (Client)

- Accès via QR Code : Le client scanne le QR code et accède instantanément à la fiche de dégustation sur son smartphone.
- Consultation des informations : Affichage optimisé pour le mobile avec les détails des produits, des images, et des recommandations.
- Partage de la fiche : Possibilité pour le client de partager la fiche via des liens (email, réseaux sociaux, etc.).

### 3.4 Administration et support

- Gestion des utilisateurs : L’administrateur doit pouvoir ajouter ou supprimer des artisans.
- Support : Module de support intégré pour les artisans (FAQ, contact).

## 4. Contraintes techniques

### 4.1 Application mobile (Artisans)

Disponible sur Android et iOS.

Fonctionnalité offline : L’application doit permettre la création de fiches hors ligne, avec synchronisation une fois la connexion restaurée.

### 4.2 API de génération de fiches

Utilisation d’une API externe pour générer automatiquement les descriptions des produits sur la fiche.

L’API doit être accessible et répondre dans un délai inférieur à 1 seconde pour une bonne expérience utilisateur.

### 4.3 Sécurité

Authentification : Chaque artisan doit s'authentifier via un système sécurisé (OAuth 2.0 ou autre).

Protection des données : Respect du RGPD pour la gestion des données clients (aucune donnée personnelle stockée).

## 5. Critères d’acceptation

- Création de fiches : L’artisan peut créer une fiche complète avec QR code en moins de 3 minutes.
- Temps de réponse de l’application : L’application doit répondre en moins de 2 secondes lors de la création ou la consultation des fiches.
- Consultation des fiches : Le client peut consulter la fiche de dégustation en moins de 3 secondes après le scan du QR code.
- Facilité d’utilisation : L'interface de l’application doit être intuitive et ne pas nécessiter plus de 10 minutes de prise en main pour un nouvel utilisateur.

## 6. Hypothèses et risques

### 6.1 Hypothèses

Les artisans sont habitués à utiliser des outils numériques et possèdent des smartphones.
Les clients disposent d'un smartphone pour scanner le QR code.

### 6.2 Risques

- Indisponibilité de l'API : En cas de panne de l’API de génération des fiches, l’artisan ne pourra pas créer de fiches.
- Problèmes de connexion : Si le client n'a pas de connexion internet, il ne pourra pas consulter la fiche via le QR code.
- Complexité de l'interface : Si l'interface de l'application est trop complexe, les artisans pourraient être réticents à l'utiliser.

## 7. Planning et jalons

- Conception de l’application (2 semaines) : Définition des interfaces, choix technologiques.
- Développement API (3 semaines) : Mise en place de l’API de génération des fiches.
- Développement de l’application mobile (4 semaines) : Création des fonctionnalités principales et de l’interface utilisateur.
- Tests et validation (2 semaines) : Tests fonctionnels, tests de performance, recette finale.
  Mise en production : Déploiement sur les stores et ouverture aux utilisateurs.

## 8. Equipes & ressources

- 1 chef de projet
- 1 testeur
- 1 designer/maquetteur
- 3 développeurs confirmés
