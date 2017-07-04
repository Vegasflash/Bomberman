using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip bgm;
    private const float PIXEL_PER_UNIT = 100;
    private const int TILE_SIZE = 64;

    private int[,] m_Tiles = new int[8, 8] { {0, 0, 0, 0, 0, 0, 0, 0 },
                                             {0, 1, 0, 0, 0, 0, 0, 0 },
                                             {0, 1, 0, 0, 0, 0, 0, 0 },
                                             {0, 1, 0, 0, 0, 0, 0, 0 },
                                             {0, 1, 0, 0, 0, 0, 0, 0 },
                                             {0, 1, 0, 0, 0, 0, 0, 0 },
                                             {0, 1, 1, 1, 0, 0, 0, 0 },
                                             {0, 0, 0, 0, 0, 0, 0, 0 },};

    private const int GRID_WIDTH = 8;
    private const int GRID_HEIGTH = 8;

    public GameObject[] m_WallList;
    public GameObject[] m_BreakableWallList;
    public GameObject[] m_FloorList;

    public LevelData m_LevelData;
	
	void Start ()
    {

        Vector2 initialSpawnPos = new Vector2(-(Screen.width / 2f - TILE_SIZE / 2f) / PIXEL_PER_UNIT, (Screen.height / 2f - TILE_SIZE / 2f) / PIXEL_PER_UNIT);

        /*for (int i = 0; i < GRID_WIDTH; i++)
        {
            for (int j = 0; j < GRID_HEIGTH; j++)
            {
                Vector2 offset = new Vector2(TILE_SIZE / PIXEL_PER_UNIT * j, -TILE_SIZE / PIXEL_PER_UNIT * i);
                Vector2 spawnPos = initialSpawnPos + offset;

                // Heart
                // HardCoded
                //CreateTile((ETileType)m_Tiles[i, j], spawnPos);

                if (i == 0 || i == GRID_WIDTH - 1 || j == 0 || j == GRID_HEIGTH - 1)
                {
                    CreateTile(ETileType.Wall, spawnPos);
                }
                else if (i == 1 || i == GRID_WIDTH - 2 || j == 1 || j == GRID_HEIGTH - 2)
                {
                    CreateTile(ETileType.Floor, spawnPos);
                }
                else
                {
                    CreateTile((ETileType)Random.Range(0, 2), spawnPos);
                }

            }
        }*/
        
        // LevelEditor
        for (int i = 0; i < m_LevelData.GetWidth(); i++)
        {
            for (int j = 0; j < m_LevelData.GetHeight(); j++)
            {
                Vector2 spawnPos = initialSpawnPos + new Vector2(TILE_SIZE * i / PIXEL_PER_UNIT, -TILE_SIZE * j / PIXEL_PER_UNIT);

                CreateTile(m_LevelData.Tiles[i][j], spawnPos);
            }
        }
    }

    private void CreateTile(ETileType aType, Vector2 aSpawnPos)
    {
        GameObject go;

        switch (aType)
        {
            case ETileType.BreakWall:
                go = Instantiate(m_BreakableWallList[Random.Range(0, m_BreakableWallList.Length)]);
                break;
            case ETileType.Floor:
                go = Instantiate(m_FloorList[Random.Range(0, m_FloorList.Length)]);
                break;
            case ETileType.Wall:
                go = Instantiate(m_WallList[Random.Range(0, m_WallList.Length)]);
                break;
            default:
                Debug.LogWarning("ETileType: " + aType + " is not handled.");
                go = Instantiate(m_WallList[Random.Range(0, m_WallList.Length)]);
                break;
        }

        go.transform.position = aSpawnPos;
    }

    public void OnButtonClick()
    {
        AudioManager.instance.StopBGM(bgm);
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync(y);
    }
}
