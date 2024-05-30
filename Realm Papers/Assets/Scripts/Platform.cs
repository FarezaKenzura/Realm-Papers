using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Kurva pergerakan platform.")]
    [SerializeField] private AnimationCurve moveCurve;
    [Tooltip("Kecepatan pergerakan platform.")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("Range")]
    [Tooltip("Jarak pergerakan platform.")]
    [SerializeField] private float moveRange;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool moving;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (moving)
        {
            MovePlatform();
        }
    }

    #region Public Methods

    /// <summary>
    /// Memindahkan platform ke atas.
    /// </summary>
    public void MovePlatformUp()
    {
        if (!moving)
        {
            targetPosition = initialPosition + Vector3.up * moveRange;
            moving = true;
        }
    }

    /// <summary>
    /// Memindahkan platform ke bawah.
    /// </summary>
    public void MovePlatformDown()
    {
        if (!moving)
        {
            targetPosition = initialPosition; // Kembali ke posisi awal
            moving = true;
        }
    }

    /// <summary>
    /// Mengembalikan posisi awal platform.
    /// </summary>
    /// <returns>Posisi awal platform.</returns>
    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    /// <summary>
    /// Mengembalikan posisi target platform.
    /// </summary>
    /// <returns>Posisi target platform.</returns>
    public Vector3 GetTargetPosition()
    {
        return targetPosition;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Memindahkan platform sesuai dengan kurva pergerakan.
    /// </summary>
    private void MovePlatform()
    {
        float curveValue = moveCurve.Evaluate(Time.time);
        Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, curveValue); 

        // Pindahkan platform ke posisi baru
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

        // Periksa apakah platform telah mencapai posisi target
        if (transform.position == targetPosition)
        {
            moving = false;
        }
    }

    #endregion
}