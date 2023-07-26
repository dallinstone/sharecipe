import { AppBar, Button, IconButton, Toolbar, Typography } from "@mui/material";
import MenuIcon from '@mui/icons-material/Menu';
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";


export default observer(function HeaderBar() {
    const { commonStore, drawerStore, userStore } = useStore();
    const { mobileOpen, setMobileOpen } = commonStore;
    const { drawerIsVisible, drawerWidth } = drawerStore;
    const { isLoggedIn, setIsLoggedIn, logInButtonText } = userStore;


    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    return (
        <div>
            <AppBar
                position="fixed"
                sx={{
                    width: { sm: `calc(100% - ${drawerWidth}px)` },
                    ml: { sm: `${drawerWidth}px` },
                }}
            >
                <Toolbar style={{display:"flex", justifyContent:"space-between"}}>
                    {/* <Grid> */}
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        edge="start"
                        onClick={handleDrawerToggle}
                        sx={{ mr: 2, display: { sm: 'none' } }}
                        disabled={drawerIsVisible}
                    >
                        <MenuIcon />
                    </IconButton>

                    <Typography variant="h6" noWrap component="div">
                        ShaRecipe
                    </Typography>
                    <Button
                        variant="contained"
                        onClick={() => {
                            console.log("Login");
                            setIsLoggedIn(!isLoggedIn);
                        }}
                    >
                        {logInButtonText}
                    </Button>
                    {/* </Grid> */}
                </Toolbar>
            </AppBar>
        </div>
    )
}
)