using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230621_HorrorWallGAME
{
    public class Board
    {
        public int boardSize; // 보드의 크기
        public int posX; // 플레이어의 X 좌표
        public int posY; // 플레이어의 Y 좌표

        public int randomX; // 장애물의 X 좌표
        public int randomY; // 장애물의 Y 좌표

        int[][] board = new int[25][]; // 보드 배열
        int wallCount = 0; // 생성된 장애물의 수

        const int FLOOR = 1; // 바닥을 나타내는 상수
        const int WALL = 0; // 벽을 나타내는 상수

        public void MapBoard()
        {
            boardSize = 25; // 보드의 크기 설정

            Player(); // 플레이어 초기 위치 설정

            while (true)
            {
                PrintBoard(); // 보드 출력
            }
        }

        public void Player()
        {
            posX = boardSize / 2; // 플레이어의 X 좌표를 보드의 중앙으로 설정
            posY = boardSize / 2; // 플레이어의 Y 좌표를 보드의 중앙으로 설정
        }

        public void PrintBoard()
        {
            for (int y = 0; y < boardSize; y++)
            {
                board[y] = new int[boardSize * 2]; // 보드 배열 초기화
                for (int x = 0; x < boardSize * 2; x++)
                {
                    board[y][x] = 0; // 보드 배열의 모든 요소를 0으로 설정 (맵 전체 보드 생성)
                }
            }

            for (int y = 1; y < boardSize - 1; y++)
            {
                for (int x = 1; x < boardSize * 2 - 1; x++)
                {
                    board[y][x] = 1; // 바닥을 나타내는 1로 설정
                }
            }

            // 장애물 생성
            while (wallCount < 10)
            {
                Random random = new Random();
                int randomX = random.Next(1, boardSize * 2 - 1); // 장애물의 X 좌표 랜덤 설정
                int randomY = random.Next(1, boardSize - 1); // 장애물의 Y 좌표 랜덤 설정

                if (board[randomY][randomX] == 1)
                {
                    board[randomY][randomX] = 0; // 벽을 나타내는 0으로 설정
                    wallCount++; // 생성된 장애물의 수 증가
                }
            }

            while (true)
            {
                // 플레이어 위치 표시
                board[posY][posX] = 3;

                // 보드 출력
                for (int y = 0; y < boardSize; y++)
                {
                    for (int x = 0; x < boardSize * 2; x++)
                    {
                        if (board[y][x] == WALL)
                        {
                            Console.Write("■"); // 벽을 나타내는 문자 출력
                        }
                        else if (board[y][x] == FLOOR)
                        {
                            Console.Write("□"); // 바닥을 나타내는 문자 출력
                        }
                        else if (board[y][x] == 3)
                        {
                            Console.Write("●"); // 플레이어를 나타내는 문자 출력
                        }
                    }
                    Console.WriteLine();
                }

                ConsoleKeyInfo userInput;
                userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.W:
                        if (board[posY - 1][posX] == 1)
                        {
                            board[posY][posX] = 1; // 이전 위치를 바닥으로 설정
                            posY--; // 플레이어의 위치를 위로 이동
                        }
                        break;

                    case ConsoleKey.A:
                        if (board[posY][posX - 1] == 1)
                        {
                            board[posY][posX] = 1; // 이전 위치를 바닥으로 설정
                            posX--; // 플레이어의 위치를 왼쪽으로 이동
                        }
                        break;

                    case ConsoleKey.S:
                        if (board[posY + 1][posX] == 1)
                        {
                            board[posY][posX] = 1; // 이전 위치를 바닥으로 설정
                            posY++; // 플레이어의 위치를 아래로 이동
                        }
                        break;

                    case ConsoleKey.D:
                        if (board[posY][posX + 1] == 1)
                        {
                            board[posY][posX] = 1; // 이전 위치를 바닥으로 설정
                            posX++; // 플레이어의 위치를 오른쪽으로 이동
                        }
                        break;
                }

                Console.Clear(); // 콘솔 화면을 지움
            }
        }
    }

    //public void Wall()
    //{
    //    for(int i = 0; i <boardSize /2; i++)
    //    {
    //        Random random = new Random();

    //        randomY = random.Next(boardSize);
    //        randomX = random.Next(boardSize);


    //    }
    //}

    //if (x == posX && y == posY)
    //            {
    //               //Console.ForegroundColor = ConsoleColor.Magenta;
    //                //Console.Write('ξ');

    //            }
    //            else if (y == 0 || y == boardSize - 1 || x == 0 || x == boardSize* 2 - 1)   //벽
    //            {
    //                //Console.ForegroundColor = ConsoleColor.DarkMagenta;
    //                //Console.Write('■');     
    //            }
    //             else
    //             {
    //                //Console.ForegroundColor = ConsoleColor.Black;
    //                //Console.Write('■');

    //             }


}

