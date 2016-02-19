﻿using System;
using System.Text;

namespace RocksDbSharp
{
    public class WriteBatch : IDisposable, IRocksDbHandle
    {
        private IntPtr handle;
        private Encoding defaultEncoding = Encoding.UTF8;

        public WriteBatch()
            : this(Native.Instance.rocksdb_writebatch_create())
        {
        }

        public WriteBatch(byte[] rep, long size)
            : this(Native.Instance.rocksdb_writebatch_create_from(rep, size))
        {
        }

        private WriteBatch(IntPtr handle)
        {
            this.handle = handle;
        }

        public IntPtr Handle { get { return handle; } }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                Native.Instance.rocksdb_writebatch_destroy(handle);
                handle = IntPtr.Zero;
            }
        }

        public WriteBatch Clear()
        {
            Native.Instance.rocksdb_writebatch_clear(handle);
            return this;
        }

        public int Count()
        {
            return Native.Instance.rocksdb_writebatch_count(handle);
        }

        public WriteBatch Put(string key, string val, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = defaultEncoding;
            Native.Instance.rocksdb_writebatch_put(handle, key, val, encoding);
            return this;
        }

        public WriteBatch Put(byte[] key, byte[] val)
        {
            return Put(key, (ulong)key.Length, val, (ulong)val.Length);
        }

        public WriteBatch Put(byte[] key, ulong klen, byte[] val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_put(handle, key, klen, val, vlen);
            return this;
        }

        public unsafe void Put(byte* key, ulong klen, byte* val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_put(handle, key, klen, val, vlen);
        }

        public WriteBatch PutCf(IntPtr columnFamily, byte[] key, ulong klen, byte[] val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_put_cf(handle, columnFamily, key, klen, val, vlen);
            return this;
        }

        public unsafe void PutCf(IntPtr columnFamily, byte* key, ulong klen, byte* val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_put_cf(handle, columnFamily, key, klen, val, vlen);
        }

        public WriteBatch Putv(int numKeys, IntPtr keysList, IntPtr keysListSizes, int numValues, IntPtr valuesList, IntPtr valuesListSizes)
        {
            Native.Instance.rocksdb_writebatch_putv(handle, numKeys, keysList, keysListSizes, numValues, valuesList, valuesListSizes);
            return this;
        }

        public WriteBatch PutvCf(IntPtr columnFamily, int numKeys, IntPtr keysList, IntPtr keysListSizes, int numValues, IntPtr valuesList, IntPtr valuesListSizes)
        {
            Native.Instance.rocksdb_writebatch_putv_cf(handle, columnFamily, numKeys, keysList, keysListSizes, numValues, valuesList, valuesListSizes);
            return this;
        }

        public WriteBatch Merge(byte[] key, ulong klen, byte[] val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_merge(handle, key, klen, val, vlen);
            return this;
        }

        public unsafe void Merge(byte* key, ulong klen, byte* val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_merge(handle, key, klen, val, vlen);
        }

        public WriteBatch MergeCf(IntPtr columnFamily, byte[] key, ulong klen, byte[] val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_merge_cf(handle, columnFamily, key, klen, val, vlen);
            return this;
        }

        public unsafe void MergeCf(IntPtr columnFamily, byte* key, ulong klen, byte* val, ulong vlen)
        {
            Native.Instance.rocksdb_writebatch_merge_cf(handle, columnFamily, key, klen, val, vlen);
        }

        public WriteBatch Mergev(int numKeys, IntPtr keysList, IntPtr keysListSizes, int numValues, IntPtr valuesList, IntPtr valuesListSizes)
        {
            Native.Instance.rocksdb_writebatch_mergev(handle, numKeys, keysList, keysListSizes, numValues, valuesList, valuesListSizes);
            return this;
        }

        public WriteBatch MergevCf(IntPtr columnFamily, int numKeys, IntPtr keysList, IntPtr keysListSizes, int numValues, IntPtr valuesList, IntPtr valuesListSizes)
        {
            Native.Instance.rocksdb_writebatch_mergev_cf(handle, columnFamily, numKeys, keysList, keysListSizes, numValues, valuesList, valuesListSizes);
            return this;
        }

        public WriteBatch Delete(byte[] key)
        {
            return Delete(key, (ulong)key.Length);
        }

        public WriteBatch Delete(byte[] key, ulong klen)
        {
            Native.Instance.rocksdb_writebatch_delete(handle, key, klen);
            return this;
        }

        public unsafe void Delete(byte* key, ulong klen)
        {
            Native.Instance.rocksdb_writebatch_delete(handle, key, klen);
        }

        public WriteBatch DeleteCf(IntPtr columnFamily, byte[] key, ulong klen)
        {
            Native.Instance.rocksdb_writebatch_delete_cf(handle, columnFamily, key, klen);
            return this;
        }

        public unsafe void DeleteCf(IntPtr columnFamily, byte* key, ulong klen)
        {
            Native.Instance.rocksdb_writebatch_delete_cf(handle, columnFamily, key, klen);
        }

        public WriteBatch Deletev(int numKeys, IntPtr keysList, IntPtr keysListSizes)
        {
            Native.Instance.rocksdb_writebatch_deletev(handle, numKeys, keysList, keysListSizes);
            return this;
        }

        public WriteBatch DeletevCf(IntPtr columnFamily, int numKeys, IntPtr keysList, IntPtr keysListSizes)
        {
            Native.Instance.rocksdb_writebatch_deletev_cf(handle, columnFamily, numKeys, keysList, keysListSizes);
            return this;
        }

        public WriteBatch PutLogData(byte[] blob, ulong len)
        {
            Native.Instance.rocksdb_writebatch_put_log_data(handle, blob, len);
            return this;
        }

        public WriteBatch Iterate(IntPtr state, WriteBatchIteratePutCallback put, WriteBatchIterateDeleteCallback deleted)
        {
            Native.Instance.rocksdb_writebatch_iterate(handle, state, put, deleted);
            return this;
        }

        public IntPtr Data(ulong size)
        {
            return Native.Instance.rocksdb_writebatch_data(handle, size);
        }
    }
}
