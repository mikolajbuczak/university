namespace AStar
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Input;
    using System.Collections.Generic;
    using System;

    public partial class MainWindow : Window
    {
        #region Layout Variables
        private static readonly int gridSize = 9;
        private static readonly int TileSize = 75;


        private bool drawingEmptyTile = true;
        private bool drawingWallTile = false;
        private bool drawingStartTile = false;
        private bool drawingEndTile = false;

        private bool hasStart = false;
        private bool hasEnd = false;

        private bool canDraw = true;

        private readonly Border[,] tiles = new Border[gridSize, gridSize];

        private readonly Label[,] gs = new Label[gridSize, gridSize];
        private readonly Label[,] hs = new Label[gridSize, gridSize];
        private readonly Label[,] fs = new Label[gridSize, gridSize];

        private readonly SolidColorBrush emptyTileColor = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
        private readonly SolidColorBrush wallTileColor = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        private readonly SolidColorBrush startTileColor = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
        private readonly SolidColorBrush endTileColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        private readonly SolidColorBrush openTileColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        private readonly SolidColorBrush closedTileColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
        private readonly SolidColorBrush pathColor = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));

        private SolidColorBrush oldColor;

        #endregion

        #region Algorithm Variables
        private static readonly int neighbourDistance = 10;
        private static readonly int diagonalDistance = 14;

        private Node startNode;
        private Node endNode;

        public enum States
        {
            Empty = 0,
            Wall = 1,
            Start = 2,
            End = 3,
            Open = 4,
            Closed = 5,
            Path = 6
        }

        private readonly Node[,] nodes = new Node[gridSize, gridSize];
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            AddTiles();
        }

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (!canDraw) return;

            Border tile = sender as Border;

            if (drawingStartTile && hasStart) return;
            if (drawingEndTile && hasEnd) return;

            if (oldColor == startTileColor && !drawingStartTile) hasStart = false; 
            if (oldColor == endTileColor && !drawingStartTile) hasEnd = false; 

            oldColor = (SolidColorBrush)tile.Background;

            if (drawingStartTile) hasStart = true;
            if (drawingEndTile) hasEnd = true;

            if (hasStart && hasEnd) AlgorithmBtn.IsEnabled = true;
        }

        private void Tile_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!canDraw) return;

            Border tile = sender as Border;

            tile.Background = oldColor;
        }

        private void Tile_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!canDraw) return;

            Border tile = sender as Border;

            oldColor = (SolidColorBrush)tile.Background;

            SolidColorBrush newColor = null;

            if (drawingEmptyTile == true) newColor = emptyTileColor;
            else if (drawingWallTile == true) newColor = wallTileColor;
            else if (drawingStartTile == true) newColor = startTileColor;
            else if (drawingEndTile == true) newColor = endTileColor;


            tile.Background = newColor;
        }

        private void EmptyBtn_Click(object sender, RoutedEventArgs e)
        {
            drawingEmptyTile = true;
            drawingWallTile = false;
            drawingStartTile = false;
            drawingEndTile = false;

            EmptyBtn.IsEnabled = false;
            WallBtn.IsEnabled = true;
            StartBtn.IsEnabled = true;
            EndBtn.IsEnabled = true;
        }

        private void WallBtn_Click(object sender, RoutedEventArgs e)
        {
            drawingEmptyTile = false;
            drawingWallTile = true;
            drawingStartTile = false;
            drawingEndTile = false;

            EmptyBtn.IsEnabled = true;
            WallBtn.IsEnabled = false;
            StartBtn.IsEnabled = true;
            EndBtn.IsEnabled = true;
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            drawingEmptyTile = false;
            drawingWallTile = false;
            drawingStartTile = true;
            drawingEndTile = false;

            EmptyBtn.IsEnabled = true;
            WallBtn.IsEnabled = true;
            StartBtn.IsEnabled = false;
            EndBtn.IsEnabled = true;
        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            drawingEmptyTile = false;
            drawingWallTile = false;
            drawingStartTile = false;
            drawingEndTile = true;

            EmptyBtn.IsEnabled = true;
            WallBtn.IsEnabled = true;
            StartBtn.IsEnabled = true;
            EndBtn.IsEnabled = false;
        }

        private void AlgorithmBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNodes();
            AddLabels();

            EmptyBtn.IsEnabled = false;
            WallBtn.IsEnabled = false;
            StartBtn.IsEnabled = false;
            EndBtn.IsEnabled = false;
            AlgorithmBtn.IsEnabled = false;

            canDraw = false;

            Node currentNode = startNode;
            currentNode.State = States.Closed;
            ChangeColor(currentNode);

            var openNodes = new List<Node>();
            while(true)
            {
                for (int y = -1; y < 2; y++)
                {
                    for (int x = -1; x < 2; x++)
                    {
                        if (x == 0 && y == 0) continue;
                        int neighborX = currentNode.X + x;
                        int neighborY = currentNode.Y + y;
                        try
                        {
                            Node neighbor = nodes[neighborY, neighborX];

                            if (neighbor.State == States.Wall || neighbor.State == States.Closed) continue;
                            if (neighbor.State == States.End)
                            {
                                neighbor.Predecessor = currentNode;
                                Node tmp = neighbor;
                                while(tmp != null)
                                {
                                    tmp.State = States.Path;
                                    ChangeColor(tmp);
                                    tmp = tmp.Predecessor;
                                }
                                return;
                            }
                            if (neighbor.HCost == 0)
                            {
                                neighbor.HCost = CalculateHeuristics(neighbor);
                                hs[neighborY, neighborX].Content = neighbor.HCost.ToString();
                                hs[neighborY, neighborX].Opacity = 1;
                            }

                            int g = CalculateCost(currentNode, neighbor);
                            if (g < neighbor.GCost || neighbor.GCost == 0)
                            {
                                neighbor.GCost = g;
                                gs[neighborY, neighborX].Content = neighbor.GCost.ToString();
                                gs[neighborY, neighborX].Opacity = 1;

                                neighbor.FCost = neighbor.GCost + neighbor.HCost;
                                fs[neighborY, neighborX].Content = neighbor.FCost.ToString();
                                fs[neighborY, neighborX].Opacity = 1;

                                neighbor.Predecessor = currentNode;
                            }

                            if (neighbor.State != States.Open) openNodes.Add(neighbor);

                            neighbor.State = States.Open;
                            ChangeColor(neighbor);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            //neigbor out of bounds
                        }
                    }//end of inner for
                }// end of outer for

                if (openNodes.Count == 0) throw new Exception("No possible connection between start and finish.");
                Node temp = openNodes[0];
                foreach (Node openNode in openNodes)
                    if ((openNode.FCost < temp.FCost) ||
                        (openNode.FCost == temp.FCost && openNode.HCost < temp.HCost))
                        temp = openNode;
                currentNode = temp;
                openNodes.Remove(currentNode);
                currentNode.State = States.Closed;
                ChangeColor(currentNode);
            }
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            drawingEmptyTile = true;
            drawingWallTile = false;
            drawingStartTile = false;
            drawingEndTile = false;

            EmptyBtn.IsEnabled = false;
            WallBtn.IsEnabled = true;
            StartBtn.IsEnabled = true;
            EndBtn.IsEnabled = true;
            AlgorithmBtn.IsEnabled = false;

            hasStart = false;
            hasEnd = false;

            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                {
                    tiles[i, j].Background = emptyTileColor;

                    ImagesGrid.Children.Remove(gs[i, j]);
                    ImagesGrid.Children.Remove(hs[i, j]);
                    ImagesGrid.Children.Remove(fs[i, j]);
                }

            canDraw = true;
        }

        private void AddTiles()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    tiles[i, j] = new Border
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Background = emptyTileColor,
                        Margin = new Thickness(0.5)
                    };
                    tiles[i, j].MouseEnter += Tile_MouseEnter;
                    tiles[i, j].MouseLeave += Tile_MouseLeave;
                    tiles[i, j].MouseLeftButtonDown += Tile_MouseDown;

                    Grid.SetColumn(tiles[i, j], i);
                    Grid.SetRow(tiles[i, j], j);

                    ImagesGrid.Children.Add(tiles[i, j]);
                }
            }
        }

        private void AddLabels()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {

                    Node currentNode = nodes[i, j];
                    gs[i, j] = new Label
                    {
                        Content = "0",
                        Foreground = wallTileColor,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 16,
                        Margin = new Thickness(2),
                        Opacity = 0
                    };

                    hs[i, j] = new Label
                    {
                        Content = "0",
                        Foreground = wallTileColor,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 16,
                        Margin = new Thickness(2),
                        Opacity = 0
                    };

                    fs[i, j] = new Label
                    {
                        Content = "0",
                        Foreground = wallTileColor,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        FontSize = 24,
                        Margin = new Thickness(2),
                        Opacity = 0
                    };

                    if (currentNode.State == States.Start) 
                    {
                        fs[i, j].Content = "A";
                        fs[i, j].Opacity = 1;
                    }
                    if (currentNode.State == States.End)
                    {
                        fs[i, j].Content = "B";
                        fs[i, j].Opacity = 1;
                    }

                    if(currentNode.State != States.Start && currentNode.State != States.End && currentNode.State != States.Wall)
                    {
                        Grid.SetColumn(gs[i, j], i);
                        Grid.SetRow(gs[i, j], j);
                        ImagesGrid.Children.Add(gs[i, j]);

                        Grid.SetColumn(hs[i, j], i);
                        Grid.SetRow(hs[i, j], j);
                        ImagesGrid.Children.Add(hs[i, j]);
                    }

                    if(currentNode.State != States.Wall)
                    {
                        Grid.SetColumn(fs[i, j], i);
                        Grid.SetRow(fs[i, j], j);
                        ImagesGrid.Children.Add(fs[i, j]);
                    }
                }
            }
        }

        private void CreateNodes()
        {
            for(int i = 0; i < gridSize; i++)
                for(int j = 0; j < gridSize; j++)
                {
                    if (tiles[i, j].Background == emptyTileColor) nodes[i, j] = new Node(j, i, States.Empty);
                    if (tiles[i, j].Background == wallTileColor) nodes[i, j] = new Node(j, i, States.Wall);
                    if (tiles[i, j].Background == startTileColor)
                    {
                        nodes[i, j] = new Node(j, i, States.Start);
                        startNode = nodes[i, j];
                    }
                    if (tiles[i, j].Background == endTileColor)
                    {
                        nodes[i, j] = new Node(j, i, States.End);
                        endNode = nodes[i, j];
                    }
                }
        }

        private int CalculateCost(Node currentNode, Node neighbor)
        {
            if (neighbor.X == currentNode.X || neighbor.Y == currentNode.Y) return neighbourDistance + currentNode.GCost;
            return diagonalDistance + currentNode.GCost;
        }

        private int CalculateHeuristics(Node toUpdate)
        {
            int dx = Math.Abs(toUpdate.X - endNode.X);
            int dy = Math.Abs(toUpdate.Y - endNode.Y);
            return neighbourDistance * (dx + dy) + (diagonalDistance - 2 * neighbourDistance) * Math.Min(dx, dy);
        }

        private void ChangeColor(Node node)
        {
            if (node.State == States.Open) tiles[node.Y, node.X].Background = openTileColor;
            if (node.State == States.Closed) tiles[node.Y, node.X].Background = closedTileColor;
            if (node.State == States.Path) tiles[node.Y, node.X].Background = pathColor;
        }
    }
}
