import { makeAutoObservable } from "mobx";

export default class DrawerStore {

    constructor() {
        makeAutoObservable (this);
    }

    drawerWidth = 0;
    setDrawerWidth = (width: number) => {
        this.drawerWidth = width;
    }
    
    drawerIsVisible = false;
    setDrawerIsVisible = (state: boolean) => {
        this.drawerIsVisible = state;
    }

}
