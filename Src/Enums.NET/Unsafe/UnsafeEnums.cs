﻿// Enums.NET
// Copyright 2015 Tyler Brinkley. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace EnumsNET.Unsafe
{
	/// <summary>
	/// Identical to <see cref="Enums"/> but is not type safe which is useful when dealing with generics
	/// and instead throws an <see cref="ArgumentException"/> if TEnum is not an enum/>
	/// </summary>
	public static class UnsafeEnums
	{
		#region "Properties"
		/// <summary>
		/// Indicates if <typeparamref name="TEnum"/> is contiguous.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <returns>Indication if <typeparamref name="TEnum"/> is contiguous.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsContiguous<TEnum>()
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsContiguous;
		}

		/// <summary>
		/// Retrieves the underlying type of <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <returns>The underlying type of <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static Type GetUnderlyingType<TEnum>()
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.UnderlyingType;
		}
		#endregion

		#region Type Methods
		/// <summary>
		/// Retrieves <typeparamref name="TEnum"/>'s count of defined constants.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="uniqueValued"></param>
		/// <returns><typeparamref name="TEnum"/>'s count of defined constants.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static int GetDefinedCount<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDefinedCount(uniqueValued);
		}

		[Pure]
		public static EnumMemberInfo<TEnum>[] GetEnumMemberInfos<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetEnumMemberInfos(uniqueValued);
		}

		/// <summary>
		/// Retrieves an array of <typeparamref name="TEnum"/>'s defined constants' names in value order.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="uniqueValued"></param>
		/// <returns>Array of <typeparamref name="TEnum"/>'s defined constants' names in value order.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static string[] GetNames<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetNames(uniqueValued);
		}

		/// <summary>
		/// Retrieves an array of <typeparamref name="TEnum"/> defined constants' values in value order.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="uniqueValued"></param>
		/// <returns>Array of <typeparamref name="TEnum"/> defined constants' values in value order.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum[] GetValues<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetValues(uniqueValued);
		}

		/// <summary>
		/// Retrieves an array of <typeparamref name="TEnum"/> defined constants' descriptions in value order. Descriptions are taken from the <see cref="DescriptionAttribute"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="uniqueValued"></param>
		/// <returns>Array of <typeparamref name="TEnum"/> defined constants' descriptions in value order.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static string[] GetDescriptions<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDescriptions(uniqueValued);
		}

		[Pure]
		public static string[] GetDescriptionsOrNames<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDescriptionsOrNames(uniqueValued);
		}

		public static string[] GetDescriptionsOrNames<TEnum>(Func<string, string> nameFormatter, bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDescriptionsOrNames(nameFormatter, uniqueValued);
		}

		[Pure]
		public static string[] GetEnumMemberValues<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetEnumMemberValues(uniqueValued);
		}

		/// <summary>
		/// Retrieves an array of all of <typeparamref name="TEnum"/>'s defined constants' attributes in value order.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="uniqueValued"></param>
		/// <returns>Array of all of <typeparamref name="TEnum"/>'s defined constants' attributes in value order.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static Attribute[][] GetAllAttributes<TEnum>(bool uniqueValued = false)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetAllAttributes(uniqueValued);
		}

		/// <summary>
		/// Retrieves an array of <typeparamref name="TEnum"/>'s defined constants' <typeparamref name="TAttribute"/> in value order.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="uniqueValued"></param>
		/// <returns>Array of <typeparamref name="TEnum"/>'s defined constants' <typeparamref name="TAttribute"/> in value order.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TAttribute[] GetAttributes<TEnum, TAttribute>(bool uniqueValued = false)
			where TAttribute : Attribute
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetAttributes<TAttribute>(uniqueValued);
		}

		/// <summary>
		/// Returns -1 if <paramref name="x"/> is less than <paramref name="y"/> and returns 0 if <paramref name="x"/> equals <paramref name="y"/>
		/// and returns 1 if <paramref name="x"/> is greater than <paramref name="y"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static int Compare<TEnum>(TEnum x, TEnum y)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Compare(x, y);
		}
		#endregion

		#region IsValid
		/// <summary>
		/// Indicates whether <paramref name="value"/> is defined or if <typeparamref name="TEnum"/> is marked with <see cref="FlagsAttribute"/>
		/// whether it's a valid flag combination of <typeparamref name="TEnum"/>'s defined values.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value">must be <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>, <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="long"/>, <see cref="ulong"/>, or <see cref="string"/></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsValid<TEnum>(object value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates whether <paramref name="value"/> is defined or if <typeparamref name="TEnum"/> is marked with <see cref="FlagsAttribute"/>
		/// whether it's a valid flag combination of <typeparamref name="TEnum"/>'s defined values.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication whether the specified <paramref name="value"/> is defined or if <typeparamref name="TEnum"/> is marked with <see cref="FlagsAttribute"/>
		/// whether it's a valid flag combination of <typeparamref name="TEnum"/>'s defined values.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsValid<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsValid<TEnum>(sbyte value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsValid<TEnum>(byte value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsValid<TEnum>(short value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsValid<TEnum>(ushort value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsValid<TEnum>(int value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsValid<TEnum>(uint value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsValid<TEnum>(long value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}

		/// <summary>
		/// Indicates if <paramref name="value"/> is valid for <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if value is valid for <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsValid<TEnum>(ulong value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsValid(value);
		}
		#endregion

		#region IsDefined
		/// <summary>
		/// Indicates whether <paramref name="value"/> is defined in <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value">must be <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>, <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="long"/>, <see cref="ulong"/>, or <see cref="string"/></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsDefined<TEnum>(object value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Indicates whether <paramref name="value"/> is defined in <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication whether <paramref name="value"/> is defined in <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsDefined<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Indicates whether a constant with the specified <paramref name="name"/> exists in <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="name">The name to check existence.</param>
		/// <returns>Indication whether a constant with the specified <paramref name="name"/> exists in <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is null</exception>
		[Pure]
		public static bool IsDefined<TEnum>(string name)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(name);
		}

		/// <summary>
		/// Indicates whether a constant with the specified <paramref name="name"/> exists in <typeparamref name="TEnum"/>.
		/// <paramref name="ignoreCase"/> specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="name"></param>
		/// <param name="ignoreCase">Specifies whether the operation is case-insensitive.</param>
		/// <returns>Indication whether a constant with the specified <paramref name="name"/> exists in <typeparamref name="TEnum"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is null</exception>
		[Pure]
		public static bool IsDefined<TEnum>(string name, bool ignoreCase)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(name, ignoreCase);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsDefined<TEnum>(sbyte value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsDefined<TEnum>(byte value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsDefined<TEnum>(short value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsDefined<TEnum>(ushort value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsDefined<TEnum>(int value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsDefined<TEnum>(uint value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsDefined<TEnum>(long value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}

		/// <summary>
		/// Returns an indication whether a constant with the specified <paramref name="value"/> exists in the enumeration.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsDefined<TEnum>(ulong value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsDefined(value);
		}
		#endregion

		#region IsWithinUnderlyingTypesValueRange
		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(sbyte value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(byte value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(short value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(ushort value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(int value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(uint value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(long value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}

		/// <summary>
		/// Returns an indication whether the specified <paramref name="value"/> is within the underlying types value range.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool IsWithinUnderlyingTypesValueRange<TEnum>(ulong value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.IsWithinUnderlyingTypesValueRange(value);
		}
		#endregion

		#region ToEnum
		/// <summary>
		/// Converts the specified <paramref name="value"/> to an enumeration member while checking that the result is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value">must be <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>, <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="long"/>, <see cref="ulong"/>, or <see cref="string"/></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="value"/> is not a valid type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		public static TEnum ToEnum<TEnum>(object value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 8-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnum<TEnum>(sbyte value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 8-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		public static TEnum ToEnum<TEnum>(byte value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 16-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		public static TEnum ToEnum<TEnum>(short value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 16-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnum<TEnum>(ushort value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 32-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		public static TEnum ToEnum<TEnum>(int value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 32-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnum<TEnum>(uint value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 64-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		public static TEnum ToEnum<TEnum>(long value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Converts the specified 64-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="validate"/> is true and <paramref name="value"/> is not a valid value</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the underlying type's value range</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnum<TEnum>(ulong value, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnum(value, validate);
		}

		/// <summary>
		/// Tries to converts the specified <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value">must be <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>, <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="long"/>, <see cref="ulong"/>, or <see cref="string"/></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ToEnumOrDefault<TEnum>(object value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 8-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnumOrDefault<TEnum>(sbyte value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 8-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ToEnumOrDefault<TEnum>(byte value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 16-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ToEnumOrDefault<TEnum>(short value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 16-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnumOrDefault<TEnum>(ushort value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 32-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ToEnumOrDefault<TEnum>(int value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 32-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnumOrDefault<TEnum>(uint value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 64-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ToEnumOrDefault<TEnum>(long value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified 64-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. If it fails
		/// <paramref name="defaultEnum"/> is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static TEnum ToEnumOrDefault<TEnum>(ulong value, TEnum defaultEnum, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToEnumOrDefault(value, defaultEnum, validate);
		}

		/// <summary>
		/// Tries to converts the specified <paramref name="value"/> to an enumeration member while checking that the result is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value">must be <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>, <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="long"/>, <see cref="ulong"/>, or <see cref="string"/></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryToEnum<TEnum>(object value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 8-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool TryToEnum<TEnum>(sbyte value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 8-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryToEnum<TEnum>(byte value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 16-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryToEnum<TEnum>(short value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 16-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool TryToEnum<TEnum>(ushort value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 32-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryToEnum<TEnum>(int value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 32-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool TryToEnum<TEnum>(uint value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 64-bit signed integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryToEnum<TEnum>(long value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}

		/// <summary>
		/// Tries to converts the specified 64-bit unsigned integer <paramref name="value"/> to an enumeration member while checking that the <paramref name="value"/> is within the
		/// underlying types value range. The optional parameter <paramref name="validate"/> indicates whether to check that the result is valid. An indication
		/// if the operation succeeded is returned and the result of the operation or if it fails the default enumeration value is stored in the output parameter <paramref name="result"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		[CLSCompliant(false)]
		public static bool TryToEnum<TEnum>(ulong value, out TEnum result, bool validate = true)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryToEnum(value, out result, validate);
		}
		#endregion

		#region All Values Main Methods
		/// <summary>
		/// Validates that <paramref name="value"/> is valid. If it's not it throws an <see cref="ArgumentException"/> with the given <paramref name="paramName"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="paramName"></param>
		/// <returns><paramref name="value"/> for use in constructor initializers and fluent API's</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="value"/> is invalid</exception>
		[Pure]
		public static TEnum Validate<TEnum>(TEnum value, string paramName)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Validate(value, paramName);
		}

		/// <summary>
		/// Converts the specified <paramref name="value"/> to its equivalent string representation.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static string AsString<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.AsString(value);
		}

		/// <summary>
		/// Converts the specified <paramref name="value"/> to its equivalent string representation according to the specified <paramref name="format"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is an invalid value</exception>
		[Pure]
		public static string AsString<TEnum>(TEnum value, string format)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.AsString(value, format);
		}

		[Pure]
		public static string AsString<TEnum>(TEnum value, params EnumFormat[] formats)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.AsString(value, formats);
		}

		/// <summary>
		/// Converts the specified <paramref name="value"/> to its equivalent string representation according to the specified <paramref name="format"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> is null</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is an invalid value.</exception>
		[Pure]
		public static string Format<TEnum>(TEnum value, string format)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Format(value, format);
		}

		[Pure]
		public static string Format<TEnum>(TEnum value, params EnumFormat[] formats)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Format(value, formats);
		}

		/// <summary>
		/// Returns an object with the enum's underlying value.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static object GetUnderlyingValue<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetUnderlyingValue(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to an <see cref="sbyte"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="sbyte"/>'s value range without overflowing</exception>
		[Pure]
		[CLSCompliant(false)]
		public static sbyte ToSByte<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToSByte(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to a <see cref="byte"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="byte"/>'s value range without overflowing</exception>
		[Pure]
		public static byte ToByte<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToByte(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to an <see cref="short"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="short"/>'s value range without overflowing</exception>
		[Pure]
		public static short ToInt16<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToInt16(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to a <see cref="ushort"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="ushort"/>'s value range without overflowing</exception>
		[Pure]
		[CLSCompliant(false)]
		public static ushort ToUInt16<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToUInt16(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to an <see cref="int"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="int"/>'s value range without overflowing</exception>
		[Pure]
		public static int ToInt32<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToInt32(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to a <see cref="uint"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="uint"/>'s value range without overflowing</exception>
		[Pure]
		[CLSCompliant(false)]
		public static uint ToUInt32<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToUInt32(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to an <see cref="long"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="long"/>'s value range without overflowing</exception>
		[Pure]
		public static long ToInt64<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToInt64(value);
		}

		/// <summary>
		/// Tries to convert <paramref name="value"/> to a <see cref="ulong"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> cannot fit within <see cref="ulong"/>'s value range without overflowing</exception>
		[Pure]
		[CLSCompliant(false)]
		public static ulong ToUInt64<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ToUInt64(value);
		}
		#endregion

		#region Defined Values Main Methods
		[Pure]
		public static EnumMemberInfo<TEnum> GetEnumMemberInfo<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetEnumMemberInfo(value);
		}

		[Pure]
		public static EnumMemberInfo<TEnum> GetEnumMemberInfo<TEnum>(string name)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetEnumMemberInfo(name);
		}

		[Pure]
		public static EnumMemberInfo<TEnum> GetEnumMemberInfo<TEnum>(string name, bool ignoreCase)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetEnumMemberInfo(name, ignoreCase);
		}

		/// <summary>
		/// Retrieves the name of the constant in <typeparamref name="TEnum"/> that has the specified <paramref name="value"/>. If <paramref name="value"/>
		/// is not defined null is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Name of the constant in <typeparamref name="TEnum"/> that has the specified <paramref name="value"/>. If <paramref name="value"/>
		/// is not defined null is returned.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static string GetName<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetName(value);
		}

		/// <summary>
		/// Retrieves the description of the constant in the enumeration that has the specified <paramref name="value"/>. If <paramref name="value"/>
		/// is not defined or no associated <see cref="DescriptionAttribute"/> is found then null is returned.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns>Description of the constant in the enumeration that has the specified <paramref name="value"/>. If <paramref name="value"/>
		/// is not defined or no associated <see cref="DescriptionAttribute"/> is found then null is returned.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static string GetDescription<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDescription(value);
		}

		[Pure]
		public static string GetDescriptionOrName<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDescriptionOrName(value);
		}

		public static string GetDescriptionOrName<TEnum>(TEnum value, Func<string, string> nameFormatter)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetDescriptionOrName(value, nameFormatter);
		}

		[Pure]
		public static string GetEnumMemberValue<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetEnumMemberValue(value);
		}
		#endregion

		#region Attributes
		/// <summary>
		/// Indicates if the enumerated constant with the specified <paramref name="value"/> has a <typeparamref name="TAttribute"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="value"></param>
		/// <returns>Indication if the enumerated constant with the specified <paramref name="value"/> has a <typeparamref name="TAttribute"/>.</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool HasAttribute<TEnum, TAttribute>(TEnum value)
			where TAttribute : Attribute
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.HasAttribute<TAttribute>(value);
		}

		/// <summary>
		/// Retrieves the <typeparamref name="TAttribute"/> if it exists of the enumerated constant with the specified <paramref name="value"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="value"></param>
		/// <returns><typeparamref name="TAttribute"/> of the enumerated constant with the specified <paramref name="value"/> if defined and has attribute, else null</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TAttribute GetAttribute<TEnum, TAttribute>(TEnum value)
			where TAttribute : Attribute
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetAttribute<TAttribute>(value);
		}

		/// <summary>
		/// Retrieves the <typeparamref name="TAttribute"/> if it exists of the enumerated constant with the specified <paramref name="value"/>
		/// and then applies the <paramref name="selector"/> else it returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <typeparam name="TAttribute"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="value"></param>
		/// <param name="selector"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		/// <exception cref="ArgumentNullException"><paramref name="selector"/> is null</exception>
		[Pure]
		public static TResult GetAttributeSelect<TEnum, TAttribute, TResult>(TEnum value, Func<TAttribute, TResult> selector, TResult defaultValue = default(TResult))
			where TAttribute : Attribute
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetAttributeSelect(value, selector, defaultValue);
		}

		[Pure]
		public static bool TryGetAttributeSelect<TEnum, TAttribute, TResult>(this TEnum value, Func<TAttribute, TResult> selector, out TResult result)
			where TAttribute : Attribute
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryGetAttributeSelect(value, selector, out result);
		}

		/// <summary>
		/// Retrieves an array of <typeparamref name="TAttribute"/>'s of the constant in the enumeration that has the specified <paramref name="value"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="value"></param>
		/// <returns><typeparamref name="TAttribute"/> array</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TAttribute[] GetAttributes<TEnum, TAttribute>(TEnum value)
			where TAttribute : Attribute
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetAttributes<TAttribute>(value);
		}

		/// <summary>
		/// Retrieves an array of all the <see cref="Attribute"/>'s of the constant in the enumeration that has the specified <paramref name="value"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns><see cref="Attribute"/> array if value is defined, else null</returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static Attribute[] GetAllAttributes<TEnum>(TEnum value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.GetAllAttributes(value);
		}
		#endregion

		#region Parsing
		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants
		/// to an equivalent enumerated object.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="value"/> is either an empty string or only contains white space.
		/// -or-
		/// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/></exception>
		[Pure]
		public static TEnum Parse<TEnum>(string value)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Parse(value);
		}

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants
		/// to an equivalent enumerated object. A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="value"/> is either an empty string or only contains white space.
		/// -or-
		/// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/></exception>
		[Pure]
		public static TEnum Parse<TEnum>(string value, bool ignoreCase)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Parse(value, ignoreCase);
		}

		/// <summary>
		/// Converts the string representation of an enumerated constant using the given <paramref name="parseFormatOrder"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="parseFormatOrder"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="value"/> is either an empty string or only contains white space.
		/// -or-
		/// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/></exception>
		[Pure]
		public static TEnum Parse<TEnum>(string value, params EnumFormat[] parseFormatOrder)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Parse(value, parseFormatOrder);
		}

		/// <summary>
		/// Converts the string representation of an enumerated constant using the given <paramref name="parseFormatOrder"/>.
		/// A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="parseFormatOrder"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
		/// -or-
		/// <paramref name="value"/> is either an empty string or only contains white space.
		/// -or-
		/// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/></exception>
		[Pure]
		public static TEnum Parse<TEnum>(string value, bool ignoreCase, params EnumFormat[] parseFormatOrder)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.Parse(value, ignoreCase, parseFormatOrder);
		}

		/// <summary>
		/// Tries to convert the string representation of the name or numeric value of one or more enumerated
		/// constants to an equivalent enumerated object but if it fails returns the specified default enumerated value.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ParseOrDefault<TEnum>(string value, TEnum defaultEnum)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ParseOrDefault(value, defaultEnum);
		}

		/// <summary>
		/// Tries to convert the string representation of the name or numeric value of one or more enumerated
		/// constants to an equivalent enumerated object but if it fails returns the specified default enumerated value.
		/// A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="defaultEnum"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase, TEnum defaultEnum)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ParseOrDefault(value, ignoreCase, defaultEnum);
		}

		/// <summary>
		/// Tries to convert the string representation of an enumerated constant using the given <paramref name="parseFormatOrder"/>
		/// but if it fails returns the specified default enumerated value.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="parseFormatOrder"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ParseOrDefault<TEnum>(string value, TEnum defaultEnum, params EnumFormat[] parseFormatOrder)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ParseOrDefault(value, defaultEnum, parseFormatOrder);
		}

		/// <summary>
		/// Tries to convert the string representation of an enumerated constant using the given <paramref name="parseFormatOrder"/>
		/// but if it fails returns the specified default enumerated value. A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="defaultEnum"></param>
		/// <param name="parseFormatOrder"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase, TEnum defaultEnum, params EnumFormat[] parseFormatOrder)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.ParseOrDefault(value, ignoreCase, defaultEnum, parseFormatOrder);
		}

		/// <summary>
		/// Tries to convert the string representation of the name or numeric value of one or more enumerated
		/// constants to an equivalent enumerated object. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryParse<TEnum>(string value, out TEnum result)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryParse(value, out result);
		}

		/// <summary>
		/// Tries to convert the string representation of the name or numeric value of one or more enumerated
		/// constants to an equivalent enumerated object. The return value indicates whether the conversion succeeded.
		/// A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryParse(value, ignoreCase, out result);
		}

		/// <summary>
		/// Tries to convert the string representation of an enumerated constant using the given <paramref name="parseFormatOrder"/>.
		/// The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="result"></param>
		/// <param name="parseFormatOrder"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryParse<TEnum>(string value, out TEnum result, params EnumFormat[] parseFormatOrder)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryParse(value, out result, parseFormatOrder);
		}

		/// <summary>
		/// Tries to convert the string representation of an enumerated constant using the given <paramref name="parseFormatOrder"/>.
		/// The return value indicates whether the conversion succeeded. A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="result"></param>
		/// <param name="parseFormatOrder"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
		[Pure]
		public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result, params EnumFormat[] parseFormatOrder)
		{
			VerifyTypeIsEnum<TEnum>();
			return EnumsCache<TEnum>.TryParse(value, ignoreCase, out result, parseFormatOrder);
		}
		#endregion

		#region Internal Methods
		internal static void VerifyTypeIsEnum<TEnum>()
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new ArgumentException("Type argument TEnum must be an enum");
			}
		}
		#endregion
	}
}
