using System;

namespace WebAssemblyTestApp.Model
{

    public class Building
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Image { get; init; }
        public int X { get; set; }
        public int Y { get; set; }
        public int OffsetX { get; init; }
        public int OffsetY { get; init; }
        public int RotationPointX { get { return X + OffsetX / 2; } }
        public int RotationPointY { get { return Y + OffsetY / 2; } }
        public int Rotation { get; set; } = 0;
        public bool Selected
        {
            //get => Selected;
            //set => OnSelectionChange(value);
            get; set;
        }

        private void OnSelectionChange(bool value)
        {
            Selected = value;
            OnSelectedChangeEvent?.Invoke();
        }
        public string StrokeColor
        {
            get
            {
                if (Selected)
                {
                    return "rgb(0,0,255)";
                }
                else
                {
                    return "rgb(0,255,0)";
                }
            }
        }

        public event Action OnSelectedChangeEvent;
    }
}
