// A double-precision, immutable data type for storing a two-dimensional size.
using System;

namespace Hedron
{
  /// <summary>
  /// A double-precision, immutable data type for storing a two-dimensional size.
  /// </summary>
  /// <example> To create a new <c>Size2D</c>, use:
  /// <code>
  /// Size2D size = new Size2D(width, height);
  /// </code>
  /// </example>
  /// <para>
  /// Attributes can be accessed either by name with <c>size.Width</c> and <c>size.Height</c>,
  /// or positionally with <c>size[0]</c> and <c>size[1]</c>.
  /// </para>
  /// <example>To scale a <c>Size2D</c> object, use the <c>*</c> operator:
  /// <code>
  /// bigger = size * 2;
  /// smaller = size * 0.5;
  /// </code>
  /// </example>
  /// <para>Equality is computed exactly (are the width and height the same, as
  /// doubles?).</para>
  /// <example>For approximate comparison, use <c>Size2D.IsClose</c>:
  /// <code>
  /// bool isClose = Size2D.IsClose(oneSize, anotherSize);
  /// </code>
  /// </example>
  /// <para>
  /// Closeness is computed as Euclidean distance between <c>Size2D</c>s, as Vector2s.
  /// That is, if you align the bottom-left corner of rectangles at the origin,
  /// the distance between <c>Size2D</c>s is the distance between the two top-right
  /// corners. The default tolerance is 1e-5 but can be overridden with the
  /// <c>tolerance</c> parameter.
  /// </para>
  /// <remarks>
  /// There are no limitations to the width and height values. In particular,
  /// width and height are not guaranteed to be positive nor even to be finite.
  /// </remarks>
  // Unity or C# MUST have some type like this already, no? I couldn't find any.
  // If some C# wizard wants to swing by this file and fix any idiomatic
  // antipatterns, please do. I don't quite believe that this is the Correct Way
  // to write C#... it can't be.
  internal struct Size2D : IEquatable<Size2D>
  {
    // Private instance variables for the width and height of this <c>Size2D</c>.
    private double width;
    private double height;

    /// <value>Get the width of this <c>Size2D</c>.</value>
    public double Width
    {
      get
      {
        return width;
      }
    }

    /// <value>Get the height of this <c>Size2D</c>.</value>
    public double Height
    {
      get
      {
        return height;
      }
    }

    /// <value>Get this <c>Size2D</c>'s width and height positionally.</value>
    /// <exception cref="IndexOutOfRangeException">
    /// Thrown when the supplied index is not 0 or 1.
    /// </exception>
    // public double this[int index]
    // {
    //   get
    //   {
    //     switch (index)
    //     {
    //       case 0:
    //         return width;
    //       case 1:
    //         return height;
    //       default:
    //         throw new IndexOutOfRangeException("Invalid Size2D index.");
    //     }
    //   }
    // }

    /// <summary>Construct a new <c>Size2D</c>.</summary>
    /// <param name="width">The width of this <c>Size2D</c>.</param>
    /// <param name="height">The height of this <c>Size2D</c>.</param>
    public Size2D(double width, double height)
    {
      this.width = width;
      this.height = height;
    }

    /// <summary>Scale a <c>Size2D</c> by a scalar.</summary>
    /// <param name="dim">The <c>Size2D</c> to scale.</param>
    /// <param name="k">The scalar by which to scale the <c>Size2D</c>.</param>
    /// <returns>The scaled <c>Size2D</c>.</returns>
    /// <seealso cref="Size2D.operator*(float, Size2D)" />
    public static Size2D operator *(Size2D dim, float k)
    {
      return new Size2D(dim.width * k, dim.height * k);
    }

    /// <summary>Scale a <c>Size2D</c> by a scalar.</summary>
    /// <param name="k">The scalar by which to scale the <c>Size2D</c>.</param>
    /// /// <param name="dim">The <c>Size2D</c> to scale.</param>
    /// <returns>The scaled <c>Size2D</c>.</returns>
    /// <seealso cref="Size2D.operator*(Size2D, float)" />
    public static Size2D operator *(float k, Size2D dim)
    {
      return dim * k;
    }

    /// <summary>Return whether two <c>Size2D</c>s are equal.</summary>
    /// <param name="lhs">The left <c>Size2D</c>.</param>
    /// <param name="rhs">The right <c>Size2D</c>.</param>
    /// <returns>Whether the two supplied <c>Size2D</c>s are equal.</returns>
    /// <seealso cref="Size2D.operator!=(Size2D, Size2D)" />
    /// <seealso cref="Size2D.Equals(Size2D)" />
    /// <seealso cref="Size2D.IsClose(Size2D, Size2D, double)" />
    public static bool operator ==(Size2D lhs, Size2D rhs)
    {
      return lhs.width == rhs.width && lhs.height == rhs.height;
    }

    /// <summary>Return whether two <c>Size2D</c>s are not equal.</summary>
    /// <param name="lhs">The left <c>Size2D</c>.</param>
    /// <param name="rhs">The right <c>Size2D</c>.</param>
    /// <returns>Whether the two supplied <c>Size2D</c>s are not equal.</returns>
    /// <seealso cref="Size2D.operator==(Size2D, Size2D)" />
    /// <seealso cref="Size2D.Equals(Size2D)" />
    /// <seealso cref="Size2D.IsClose(Size2D, Size2D, double)" />
    public static bool operator !=(Size2D lhs, Size2D rhs)
    {
      return !(lhs == rhs);
    }

    /// <summary>
    /// Return whether two <c>Size2D</c>s are close to equal.
    /// </summary>
    /// <para>
    /// Closeness is computed as Euclidean distance between <c>Size2D</c>s, as Vector2s.
    /// That is, if you align the bottom-left corner of rectangles at the origin,
    /// the distance between <c>Size2D</c>s is the distance between the two top-right
    /// corners. The default tolerance is 1e-5 but can be overridden with the
    /// <c>tolerance</c> parameter.
    /// </para>
    /// <param name="lhs">The left <c>Size2D</c>.</param>
    /// <param name="rhs">The right <c>Size2D</c>.</param>
    /// <param name="tolerance">The tolerance threshold for closeness.</param>
    /// <returns>Whether the two supplied <c>Size2D</c>s are close to equal.</returns>
    /// <seealso cref="Size2D.operator!=(Size2D, Size2D)" />
    /// <seealso cref="Size2D.operator==(Size2D, Size2D)" />
    /// <seealso cref="Size2D.Equals(Size2D)" />
    public static bool IsClose(Size2D lhs, Size2D rhs, double tolerance = 1e-5)
    {
      double dwidth = (lhs.width - rhs.width);
      double dheight = (lhs.height - rhs.height);
      double magnitude = dwidth * dwidth + dheight * dheight;
      return magnitude < tolerance * tolerance;
    }

    /// <summary>
    /// Return whether this <c>Size2D</c> is equal to another <c>Size2D</c>.
    /// </summary>
    /// <param name="other">
    /// Another <c>Size2D</c> with which to check equality.
    /// </param>
    /// <returns>
    /// Whether this <c>Size2D</c> is equal to another <c>Size2D</c>.
    /// </returns>
    /// <seealso cref="Size2D.operator==(Size2D, Size2D)" />
    /// <seealso cref="Size2D.operator!=(Size2D, Size2D)" />
    /// <seealso cref="Size2D.Equals(object)" />
    public bool Equals(Size2D other)
    {
      return width.Equals(other.width) && height.Equals(other.height);
    }

    /// <summary>Return whether this <c>Size2D</c> is equal to another object.</summary>
    /// <param name="other">Another object with which to check equality.</param>
    /// <returns>Whether this <c>Size2D</c> is equal to another object.</returns>
    /// <seealso cref="Size2D.operator==(Size2D, Size2D)" />
    /// <seealso cref="Size2D.operator!=(Size2D, Size2D)" />
    /// <seealso cref="Size2D.Equals(Size2D)" />
    public override bool Equals(object other)
    {
      return other is Size2D && this.Equals((Size2D)other);
    }

    /// <summary>Convert this <c>Size2D</c> into a human-readable string.</summary>
    /// <returns>A human-readable string representing this <c>Size2D</c>.</returns>
    public override string ToString()
    {
      return "Size2D(width=" + width + ", height=" + height + ")";
    }

    /// <summary>Hash this <c>Size2D</c> to an integral code.</summary>
    /// <returns>A hash code for this <c>Size2D</c>.</returns>
    public override int GetHashCode()
    {
      return width.GetHashCode() ^ height.GetHashCode() << 2;
    }
  }
}  // namespace Hedron
