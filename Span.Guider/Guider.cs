﻿using System;
using System.Buffers.Text;
using System.Runtime.InteropServices;

namespace Span.Guider;

public static class Guider
{
	private const char EqualsChar = '=';
	private const char Hyphen = '-';
	private const char Slash = '/';
    private const byte SlashByte = (byte)'/';
    private const char Underscore = '_';
	private const char Plus = '+';
    private const byte PlusByte = (byte)'+';

    public static string ToStringFromGuid(Guid id)
	{
		return Convert.ToBase64String(id.ToByteArray())
			.Replace("/", "_")
			.Replace("+", "-")
			.Replace("=", string.Empty);
	}

    public static string ToStringFromGuidOp(Guid id)
    {
		Span<byte> idBytes = stackalloc byte[16];
		Span<byte> base64Bytes = stackalloc byte[24];
		Span<char> finalChars = stackalloc char[22];

		MemoryMarshal.TryWrite(idBytes, ref id);
		Base64.EncodeToUtf8(idBytes, base64Bytes, out _, out _);

		for(var i = 0; i < 22; i++)
		{
			finalChars[i] = base64Bytes[i] switch
			{
				SlashByte => Hyphen,
				PlusByte => Underscore,
				_ => (char)base64Bytes[i]
			};
		}


		return new string(finalChars);
    }

    public static Guid ToGuidFromString(string id)
	{
		var base64 = Convert.FromBase64String(id
			.Replace("_", "/")
			.Replace("-", "+") + "==");

		return new Guid(base64);
	}

    public static Guid ToGuidFromStringOp(ReadOnlySpan<char> id)
    {
		Span<char> base64Chars = stackalloc char[24];

		for (var i = 0; i < 22; i++)
		{
			base64Chars[i] = id[i] switch
			{
				Hyphen => Slash,
				Underscore => Plus,
				_ => id[i]
			};

        }

		base64Chars[22] = EqualsChar;
        base64Chars[23] = EqualsChar;

		Span<byte> idBytes = stackalloc byte[16];

		Convert.TryFromBase64Chars(base64Chars, idBytes, out _);

        return new Guid(idBytes);
    }
}

