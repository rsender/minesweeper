namespace Minesweeper {
    internal class Smiley : Label {
        
        public Smiley(Action<object, MouseEventArgs> mouseUpActions) {
            this.BackgroundImage = Image.FromFile(@"icons\smile_raised.png");
            this.Height = 26;
            this.Width = 26;
            this.MouseDown += new MouseEventHandler(this.OnSmileyMouseDown);
            this.MouseUp += new MouseEventHandler(this.OnSmileyMouseUp);
            this.MouseUp += new MouseEventHandler(mouseUpActions);
        }

        public void Raise() {
            this.BackgroundImage = Image.FromFile(@"icons\smile_raised.png");
        }

        public void Flat() {
            this.BackgroundImage = Image.FromFile(@"icons\smile_flat.png");
        }

        public void Surprise() {
            this.BackgroundImage = Image.FromFile(@"icons\surprise.png");
        }

        public void Sunglasses() {
            this.BackgroundImage = Image.FromFile(@"icons\sunglasses.png");
        }

        public void Dead() {
            this.BackgroundImage = Image.FromFile(@"icons\dead.png");
        }

        private void OnSmileyMouseDown(object sender, MouseEventArgs e) {
            this.Flat();
        }

        private void OnSmileyMouseUp(object sender, MouseEventArgs e) {
            this.Raise();
        }
    }
}
