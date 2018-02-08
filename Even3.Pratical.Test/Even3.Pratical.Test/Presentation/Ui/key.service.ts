/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class KeyService {
    public key: number = null;
}

main.service("$keyService", KeyService);